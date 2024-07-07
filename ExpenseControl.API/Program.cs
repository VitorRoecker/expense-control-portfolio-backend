using ExpenseControl.API.Extensions;
using ExpenseControl.API.Middleware;
using ExpenseControl.CrossCutting;
using ExpenseControl.Infra.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureDatabase();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureDependecyInjection();
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureCors();
builder.Services.AddHealthChecks();

var app = builder.Build();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var context = services.GetRequiredService<DatabaseContext>();
await context.Database.MigrateAsync();
await context.Database.EnsureCreatedAsync();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseMiddleware(typeof(ExceptionMiddleware));

app.UseCors(c => c.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();
app.MapHealthChecks("/healthz");
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