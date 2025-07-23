using ItemSales.Inventory.Dtos.Request;
using ItemSales.Web.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ItemSales.Web.Client.Pages.Inventory;

public partial class Create : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private InventoryService InventoryService { get; set; } = null!;
    private CreateInventoryItemDto? Model { get; set; }
    protected override Task OnInitializedAsync()
    {
        Model ??= new CreateInventoryItemDto();
        return base.OnInitializedAsync();
    }

    public async Task Submit()
    {
        
        if (Model is null)
        {
            return;
        }
        var newItem = await InventoryService.CreateInventoryItem(Model);
        NavigationManager.NavigateTo($"/Inventory/{newItem.Id}");
    }
}