using System.ComponentModel.DataAnnotations;

namespace ItemSales.Inventory.Dtos;

public class InventoryLocationDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    public bool IsPrimary { get; set; } = true;
}