using System.ComponentModel.DataAnnotations;

namespace ItemSales2.Web.Features.SalesOrders.Models;

public class PricingMatrixModel
{
    [Key]public int PricingMatrixId { get; set; }
    public decimal StartPrice { get; set; }
    public decimal EndPrice { get; set; }
    public decimal Markup { get; set; }
}