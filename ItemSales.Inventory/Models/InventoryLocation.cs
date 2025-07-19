using System.ComponentModel.DataAnnotations;

namespace ItemSales.Inventory.Models;

public class InventoryLocation
{
    public int InventoryLocationId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    public bool IsPrimary { get; set; } = true;
}