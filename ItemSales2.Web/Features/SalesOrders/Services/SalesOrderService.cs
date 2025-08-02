using ItemSales2.Web.Features.SalesOrders.Data;
using ItemSales2.Web.Features.SalesOrders.Dtos;
using ItemSales2.Web.Features.SalesOrders.Mappers;
using ItemSales2.Web.Features.SalesOrders.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemSales2.Web.Features.SalesOrders.Services;

public class SalesOrderService
{
    private readonly SalesOrderContext _dbContext;
    public SalesOrderService(SalesOrderContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> CreateSalesOrder(CreateSalesOrderDto dto, CancellationToken ct)
    {
        var newSalesOrder = new SalesOrderModel()
        {
            CustomerId = dto.CustomerId
        };
        _dbContext.SalesOrders.Add(newSalesOrder);
        await _dbContext.SaveChangesAsync(ct);
        return newSalesOrder.SalesOrderId;
    }

    public async Task AddOrderItem(AddOrderItemDto dto, CancellationToken ct)
    {
        var order = await _dbContext.SalesOrders.FirstAsync(so => so.SalesOrderId == dto.SalesOrderId, ct);
        var item = new OrderItemModel()
        {
            SalesOrderId = dto.SalesOrderId,
            ItemId = dto.ItemId,
            Quantity = dto.Quantity,
            Price = dto.Price
        };
        order.Items.Add(item);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task RemoveOrderItem(RemoveOrderItemDto dto, CancellationToken ct)
    {
        var item = await _dbContext.OrderItems.FirstAsync(oi => oi.OrderItemId == dto.OrderItemId, ct);
        _dbContext.OrderItems.Remove(item);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task<bool> ValidateCustomer(CreateSalesOrderDto dto, CancellationToken ct)
    {
        var customer = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.ContactId == dto.CustomerId, ct);
        return customer is not null;
    }

    public async Task<List<ContactSearchResponseDto>> SearchCustomersAsync(string searchQuery, CancellationToken ct)
    {
        searchQuery = searchQuery.ToLower();
        var contactModels = await _dbContext.Contacts.Where(c =>
            (!string.IsNullOrWhiteSpace(c.CompanyName) && c.CompanyName.ToLower().Contains(searchQuery)) ||
            (!string.IsNullOrWhiteSpace(c.GivenName) && c.GivenName.ToLower().Contains(searchQuery)) ||
            (!string.IsNullOrWhiteSpace(c.Surname) && c.Surname.ToLower().Contains(searchQuery))
            ).ToListAsync(ct);

        return contactModels.ToDto();
    }

    public async Task<List<ItemSearchResponseDto>> SearchItemsAsync(string searchQuery, CancellationToken ct)
    {
        searchQuery = searchQuery.ToLower();
        var itemModels = await _dbContext.Items.Where(c =>
            (!string.IsNullOrWhiteSpace(c.Description) && c.Description.ToLower().Contains(searchQuery)) ||
            (!string.IsNullOrWhiteSpace(c.Sku) && c.Sku.ToLower().Contains(searchQuery)))
        .ToListAsync(ct);

        return itemModels.ToDto();
    }
}

public class ItemSearchResponseDto
{
    public int ItemId { get; set; }
    public string Sku { get; set; } = null!;
    public string? Description { get; set; }
}