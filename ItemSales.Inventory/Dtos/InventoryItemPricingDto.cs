namespace ItemSales.Inventory.Dtos;

public class InventoryItemPricingDto
{
    public decimal Cost { get; set; }
    public InventorySupplierDto? Supplier { get; set; } = null!;
    public DateTime? LastUpdated { get; set; }
}