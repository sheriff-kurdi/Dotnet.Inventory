

using Kurdi.Inventory.UseCases.ProductsManagement.Categories;
using Kurdi.Inventory.UseCases.ProductsManagement.Categories.CreateCategory;
using Kurdi.Inventory.UseCases.ProductsManagement.Categories.DeleteCategory;
using Kurdi.Inventory.UseCases.ProductsManagement.Categories.GetCategoryByName;
using Kurdi.Inventory.UseCases.ProductsManagement.Categories.ListCategories;
using Kurdi.Inventory.UseCases.ProductsManagement.Categories.UpdateCategory;
using Kurdi.Inventory.UseCases.ProductsManagement.Products;
using Kurdi.Inventory.UseCases.ProductsManagement.Products.CreateProduct;
using Kurdi.Inventory.UseCases.ProductsManagement.Products.DeleteProduct;
using Kurdi.Inventory.UseCases.ProductsManagement.Products.GetProductBySKU;
using Kurdi.Inventory.UseCases.ProductsManagement.Products.ListProducts;
using Kurdi.Inventory.UseCases.ProductsManagement.Products.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Kurdi.Inventory.Api.Routes.Portal
{
    public static class ProductsManagementsEndPoints
    {
        public static void UseProductsManagementsEndPoints(this WebApplication app)
        {
            RouteGroupBuilder productsManagementGroup = app.MapGroup("/api/products-management").WithTags("Products Management");


            #region productsGroup
            RouteGroupBuilder productsGroup = productsManagementGroup.MapGroup("/products").WithTags("Products");

            productsGroup.MapGet("/", async ([AsParameters] ListProductsRequest request, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new ListProductsQuery(request));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.Ok(result);

            });

            productsGroup.MapGet("/{sku}", async (string sku, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new GetProductBySkuQuery(sku));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.Ok(result);
            });

            productsGroup.MapPut("/{sku}", async (string sku, [FromBody] UpdateProductRequest request, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new UpdateProductCommand(sku, request));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.Ok(result);
            });

            productsGroup.MapPost("/", async ([FromBody] CreateProductRequest request, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateProductCommand(request));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.Created();
            });

            productsGroup.MapDelete("/{sku}", async (string sku, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteProductCommand(sku));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.NoContent();
            });
            #endregion

            #region categoriesGroup
            RouteGroupBuilder categoriesGroup = productsManagementGroup.MapGroup("/categories").WithTags("Categories");

            categoriesGroup.MapGet("/", async ([AsParameters] ListCategoriesRequest request, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new ListCategoriesQuery(request));
                if (!result.IsSuccess) return Results.BadRequest(result);

                return Results.Ok(result);
            });

            categoriesGroup.MapGet("/{name}", async (string name, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCategoryByNameQuery(name));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.Ok(result);
            });

            categoriesGroup.MapPut("/{name}", async (string name, [FromBody] UpdateCategoryRequest request, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new UpdateCategoryCommand(name, request));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.Ok(result);
            });

            categoriesGroup.MapPost("/", async ([FromBody] CreateCategoryRequest request, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateCategoryCommand(request));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.Created();
            });

            categoriesGroup.MapDelete("/{name}", async (string name, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteCategoryCommand(name));
                if (!result.IsSuccess) return Results.BadRequest(result);
                return Results.NoContent();
            });
            #endregion
        }

    }
}