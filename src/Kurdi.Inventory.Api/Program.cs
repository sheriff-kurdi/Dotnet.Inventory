
using Kurdi.Inventory.Api.Configuration;
using Kurdi.Inventory.Api.Helpers;
using Kurdi.Inventory.Api.Middleware;
using Kurdi.Inventory.Api.Routes.Portal;
using Kurdi.Inventory.Core;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.Infrastructure.DataAccess;
using Kurdi.Inventory.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
builder.Services.AddScoped<ISalesOrdersRepo, SalesOrdersRepo>();
builder.Services.AddScoped<IReceivingService, ReceivingService>();

builder.Services.AddScoped<ISalesOrderProductsRepo, SalesOrderProductsRepo>();
builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<SalesOrdersService>();

builder.Services.AddLocalization();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(MediatorConfig.GetAssemblies().ToArray()));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(cors => { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

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
