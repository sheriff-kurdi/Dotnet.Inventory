
using Kurdi.Inventory.Api.Requests.Receiving;
using Kurdi.Inventory.UseCases.Receiving;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Kurdi.Inventory.Api.Routes.Portal
{
    public static class ReceivingEndPoints
    {

        public static void UseReceivingEndPoints(this WebApplication app)
        {
            RouteGroupBuilder salesOrdersGroup = app.MapGroup("/api/receiving").WithTags("Receiving");


            salesOrdersGroup.MapPost("/", async ([FromBody] ReceiveProductRequest request, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(new ReceivingStocksCommand(request.ToReceiveProductDTO()));
                return Results.Ok();
            });

        }

    }
}