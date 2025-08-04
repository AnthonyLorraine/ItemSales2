using ItemSales2.Web.Features.SalesOrders.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemSales2.Web.Features.SalesOrders.Data;

public class SalesOrderContext : DbContext
{
    public SalesOrderContext(DbContextOptions<SalesOrderContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SalesOrder");
    }

    public DbSet<SalesOrderModel> SalesOrders { get; set; }
    public DbSet<OrderItemModel> OrderItems { get; set; }
    public DbSet<ItemModel> Items { get; set; }
    public DbSet<ContactModel> Contacts { get; set; }
    public DbSet<PricingMatrixModel> PricingMatrix { get; set; }
    public DbSet<PricingModel> Pricing { get; set; }
    
}