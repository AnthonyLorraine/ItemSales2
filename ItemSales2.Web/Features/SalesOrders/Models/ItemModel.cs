using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemSales2.Web.Features.SalesOrders.Models;

public class ItemModel
{
    [Key] public int ItemId { get; set; }
    public string Sku { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public int SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    public ContactModel Supplier { get; set; } = null!;
}