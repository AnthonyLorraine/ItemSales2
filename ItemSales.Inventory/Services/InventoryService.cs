using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Dtos.Request;
using ItemSales.Inventory.Mappers;
using ItemSales.Inventory.Models;

namespace ItemSales.Inventory.Services;

public class InventoryService : IInventoryService
{
    public async Task<InventoryItemDto> CreateAsync(CreateInventoryItemDto dto, CancellationToken cancellationToken = default)
    {
        var model = new InventoryItem
        {
            Sku = dto.Sku,
            Description = dto.Description
        };

        if (dto.Location is not null)
        {
            model.Locations.Add(dto.Location.ToModel());
        }

        var itemPriceDto = new InventoryItemPricingDto
        {
            Cost = dto.Cost,
            Supplier = dto.Supplier,
            LastUpdated = DateTime.UtcNow
        };
        
        model.Prices.Add(itemPriceDto.ToModel());

        return await Task.FromResult(model.ToDto());
    }
}