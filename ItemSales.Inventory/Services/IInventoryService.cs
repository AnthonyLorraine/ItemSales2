using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Dtos.Request;

namespace ItemSales.Inventory.Services;

public interface IInventoryService
{
    Task<InventoryItemDto> CreateAsync(CreateInventoryItemDto dto, CancellationToken cancellationToken = default);
    Task<InventoryItemDto> GetAsync(int itemId, CancellationToken cancellationToken);
}