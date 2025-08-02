using System.ComponentModel.DataAnnotations;

namespace ItemSales2.Web.Features.SalesOrders.Models;

public class OrderItemModel
{
    [Key] public int OrderItemId { get; set; }
    public int SalesOrderId { get; set; }
    public SalesOrderModel SalesOrder { get; set; } = null!;
    public int ItemId { get; set; }
    public ItemModel Item { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}