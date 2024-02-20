
using FluentValidation;
using HealthChecks.UI.Client;
using Kurdi.Inventory.Api.Configurations;
using Kurdi.Inventory.Api.Helpers;
using Kurdi.Inventory.Api.Middleware;
using Kurdi.Inventory.Api.Routes.Portal;
using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.UseCases;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddConfiguredHealthChecks();
builder.Services.AddDbContext<AppDbContext>();

#region  custom services injection
builder.Services.AddRepositories();
builder.Services.AddMediator();
builder.Services.AddDomainServices();
builder.Services.AddSettings();
builder.Services.AddCustomExceptionsHandling();
#endregion


builder.Services.AddValidatorsFromAssemblyContaining<UseCaseRoot>();



builder.Services.AddLocalization();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseCors(cors => { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
app.UseExceptionHandler(opt => { });
app.UseLanguageMiddleware();

#region endpoints
//TODO: remove to separate file
app.UseProductsManagementsEndPoints();
app.UseReceivingEndPoints();
#endregion

app.MapGet("/", () => Translator.Translate("VALIDATION:NOT_VALID_LANGUAGE"));
app.Run();

// for exposing to Integration test
public partial class Program { }