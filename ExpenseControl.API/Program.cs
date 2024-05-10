using ExpenseControl.API.Extensions;
using ExpenseControl.CrossCutting;
using ExpenseControl.Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;

var allowOrigins = "PortalCors";

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureSwagger();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                     .AddEnvironmentVariables();

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureAppSettings(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureDependecyInjection();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureCors(allowOrigins);

var app = builder.Build();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var context = services.GetRequiredService<DatabaseContext>();
await context.Database.MigrateAsync();
await context.Database.EnsureCreatedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    await app.RunAsync();

    Log.Information("Stopped cleanly");
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
    await app.StopAsync();
}
finally
{
    Log.CloseAndFlush();
    await app.DisposeAsync();
}