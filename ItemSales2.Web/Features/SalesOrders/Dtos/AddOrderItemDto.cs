namespace ItemSales2.Web.Features.SalesOrders.Dtos;

public class AddOrderItemDto
{
    public int SalesOrderId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}