using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemSales2.Web.Features.SalesOrders.Models;

public class SalesOrderModel
{
    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]public ContactModel Customer { get; set; } = null!;
    [Key] public int SalesOrderId { get; set; }

    public List<OrderItemModel> Items { get; set; } = [];
}