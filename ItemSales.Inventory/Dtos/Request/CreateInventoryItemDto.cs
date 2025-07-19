using System.ComponentModel.DataAnnotations;

namespace ItemSales.Inventory.Dtos.Request;

public class CreateInventoryItemDto
{
    [Required] 
    [StringLength(100)]
    public string Sku { get; set; } = null!;
    [StringLength(400)]
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public InventorySupplierDto? Supplier { get; set; }
    public InventoryLocationDto? Location { get; set; }
}