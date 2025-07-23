using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Dtos.Request;
using ItemSales.Inventory.Services;
using ItemSales.Web.Api.Setup;
using Microsoft.AspNetCore.Mvc;

namespace ItemSales.Web.Api.Inventory.Endpoints;

public class GetEndpoint : IEndpoint
    {
        public static async Task<IResult> GetInventoryItem(
            [FromRoute]int itemId, 
            [FromServices] IInventoryService inventoryService,
            CancellationToken cancellationToken)
        {
            var newInventoryItem = await inventoryService.GetAsync(itemId, cancellationToken);
            return TypedResults.Ok(newInventoryItem);
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.Inventory + "/{itemId:int}", GetInventoryItem)
                .AllowAnonymous()
                .DisableAntiforgery()
                .ProducesValidationProblem()
                .ProducesValidationProblem(StatusCodes.Status500InternalServerError)
                .Produces(StatusCodes.Status200OK, typeof(InventoryItemDto));
        }
    
}