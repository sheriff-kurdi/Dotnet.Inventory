
using Kurdi.Inventory.Api.Requests.SalesOrders;
using Kurdi.Inventory.Api.Requests.Stock;
using Kurdi.Inventory.Api.Responses;
using Kurdi.Inventory.Api.Responses.Categories;
using Kurdi.Inventory.Api.Responses.Stock;
using Kurdi.Inventory.Core.Contracts;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.DTOs.SalesOrders;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Kurdi.Inventory.Api.Routes.Portal
{
    public static class SalesOrdersEndPoints
    {

        public static void UseSalesOrdersEndPoints(this WebApplication app)
        {
            RouteGroupBuilder salesOrdersGroup = app.MapGroup("/api/salesOrders").WithTags("Sales Orders");


            salesOrdersGroup.MapGet("/", async ([AsParameters] CategoriesRequestParameters requestParameters, [FromServices] ICategoriesRepo categoriesRepository) =>
            {
                var categories = categoriesRepository.FindAll()
                .Include(c => c.CategoryDetails)
                .Skip(requestParameters.PageNumber - 1)
                .Take(requestParameters.PageSize)
                .Select(c => new CategoryResponse()
                {
                    Name = c.Name,
                    TranslatedName = c.CategoryDetails.FirstOrDefault(d => d.LanguageCode == "ar")!.TranslatedName,
                    Description = c.CategoryDetails.FirstOrDefault(d => d.LanguageCode == "ar")!.Description,
                    IsParent = c.HasParent,
                    Parent = c.ParentName
                });


                if (!string.IsNullOrEmpty(requestParameters.Query))
                {
                    categories = categories.Where(c => c.Name == requestParameters.Query.ToUpper().Trim() || c.TranslatedName.Contains(requestParameters.Query));
                }

                return Results.Ok(new Responses.PaginatedResponse<List<CategoryResponse>>(await categories.ToListAsync(), requestParameters.PageNumber, requestParameters.PageSize, categoriesRepository.Count()));
            });


            salesOrdersGroup.MapPost("/", ([FromBody] SalesOrderRequest salesOrderRequest, [FromServices] SalesOrdersService salesOrdersService) =>
            {
                SalesOrder salesOrder = salesOrdersService.CreateOrder(new SalesOrderDTO(salesOrderRequest.SalesOrderItems));
                return new BaseResponse<SalesOrder>(salesOrder);
            });



        }

    }
}