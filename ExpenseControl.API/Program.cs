using ExpenseControl.API.Extensions;
using ExpenseControl.CrossCutting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var allowOrigins = "PortalCors";

var builder = WebApplication.CreateBuilder(args);

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

app.Run();
