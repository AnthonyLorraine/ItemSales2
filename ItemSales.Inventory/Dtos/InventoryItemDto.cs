using System.ComponentModel.DataAnnotations;

namespace ItemSales.Inventory.Dtos;

public class InventoryItemDto
{
    public int Id { get; set; }
    [StringLength(100)]
    [Required]
    public string Sku { get; set; } = null!;
    [StringLength(400)]
    public string? Description { get; set; }
    public List<InventoryLocationDto> Locations { get; set; } = [];
    public List<InventoryItemPricingDto> Prices { get; set; } = [];
}