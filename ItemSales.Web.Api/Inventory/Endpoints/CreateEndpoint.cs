using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Dtos.Request;
using ItemSales.Inventory.Services;
using ItemSales.Web.Api.Setup;
using Microsoft.AspNetCore.Mvc;

namespace ItemSales.Web.Api.Inventory.Endpoints;

public class CreateEndpoint : IEndpoint
{
    public static async Task<IResult> CreateInventoryItem(
        [FromBody] CreateInventoryItemDto createDto, 
        [FromServices] IInventoryService inventoryService,
        CancellationToken cancellationToken)
    {
        var newInventoryItem = await inventoryService.CreateAsync(createDto, cancellationToken);
        return TypedResults.Created($"/{newInventoryItem.Id}", newInventoryItem);
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.Inventory, CreateInventoryItem)
            .AllowAnonymous()
            .DisableAntiforgery()
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status201Created, typeof(InventoryItemDto))
            .Produces(StatusCodes.Status500InternalServerError, typeof(ProblemDetails));;
    }
}