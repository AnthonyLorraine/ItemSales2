namespace ItemSales.Inventory.Models;

public class InventoryPricing
{
    public int InventoryPricingId { get; set; }
    public decimal Cost { get; set; }
    public InventorySupplier? Supplier { get; set; }
    public DateTime? LastUpdated { get; set; }
}