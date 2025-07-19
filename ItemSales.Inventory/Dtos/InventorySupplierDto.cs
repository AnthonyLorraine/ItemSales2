using System.ComponentModel.DataAnnotations;

namespace ItemSales.Inventory.Dtos;

public class InventorySupplierDto
{
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = null!;
}