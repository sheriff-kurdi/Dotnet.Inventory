
using FluentValidation;
using Kurdi.Inventory.Api.Configurations;
using Kurdi.Inventory.Api.Helpers;
using Kurdi.Inventory.Api.Middleware;
using Kurdi.Inventory.Api.Routes.Portal;
using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.UseCases;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
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
app.UseCors(cors => { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
app.UseExceptionHandler(opt => { });
app.UseLanguageMiddleware();

#region endpoints
//TODO: remove to seperate file
app.UseProductsManagementsEndPoints();
app.UseReceivingEndPoints();
#endregion

app.MapGet("/", () =>
{
    return Translator.Translate("VALIDATION:NOT_VALID_LANGUAGE");
});
app.Run();
