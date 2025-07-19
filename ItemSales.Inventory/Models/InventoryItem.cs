using System.ComponentModel.DataAnnotations;

namespace ItemSales.Inventory.Models;

public class InventoryItem
{
    public int InventoryItemId { get; set; }
    [StringLength(100)]
    public string Sku { get; set; } = null!;
    [StringLength(400)]
    public string? Description { get; set; }
    public List<InventoryLocation> Locations { get; set; } = [];
    public List<InventoryPricing> Prices { get; set; } = [];
}