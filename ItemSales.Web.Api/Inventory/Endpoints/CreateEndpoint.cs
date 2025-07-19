namespace ItemSales.Web.Api.Inventory.Endpoints;

public static class CreateEndpoint
{
    public static async Task<IResult> CreateInventoryItem()
    {
        await Task.Delay(1);
        return Results.Ok();
    }
}