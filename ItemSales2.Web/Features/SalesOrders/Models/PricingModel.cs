using System.ComponentModel.DataAnnotations;

namespace ItemSales2.Web.Features.SalesOrders.Models;

public class PricingModel
{
    [Key] public int PricingId { get; set; }
    public string Name { get; set; } = null!;
    public List<PricingMatrixModel> Matrix { get; set; } = [];
}