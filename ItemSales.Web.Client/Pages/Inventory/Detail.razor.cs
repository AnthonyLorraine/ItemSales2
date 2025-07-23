using ItemSales.Inventory.Dtos;
using ItemSales.Web.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ItemSales.Web.Client.Pages.Inventory;

public partial class Detail : ComponentBase
{
    [Parameter] public int ItemId { get; set; }
    [Inject] private InventoryService InventoryService { get; set; } = null!;
    private InventoryItemDto InventoryItem { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        var item = await InventoryService.GetInventoryItem(ItemId);
        if (item is null) return;
        InventoryItem = item;
    }
}