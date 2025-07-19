using System.ComponentModel.DataAnnotations;

namespace ItemSales.Inventory.Models;

public class InventorySupplier
{
    public int InventorySupplierId { get; set; }
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = null!;
}