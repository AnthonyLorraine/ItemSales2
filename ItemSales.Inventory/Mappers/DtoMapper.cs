using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Models;

namespace ItemSales.Inventory.Mappers;

public static class DtoMapper
{
    public static InventoryItemDto ToDto(this InventoryItem model)
    {
        return new InventoryItemDto
        {
            Id = model.InventoryItemId,
            Sku = model.Sku,
            Description = model.Description,
            Locations = model.Locations.ToDto(),
            Prices = model.Prices.ToDto()
        };
    }

    public static List<InventoryLocationDto> ToDto(this List<InventoryLocation> models)
    {
        return models.Select(ToDto).ToList();
    }
    public static InventoryLocationDto ToDto(this InventoryLocation model)
    {
        return new InventoryLocationDto
        {
            Name = model.Name,
            IsPrimary = model.IsPrimary
        };
    }
    public static List<InventoryItemPricingDto> ToDto(this List<InventoryPricing> models)
    {
        return models.Select(ToDto).ToList();
    }
    public static InventoryItemPricingDto ToDto(this InventoryPricing model)
    {
        return new InventoryItemPricingDto
        {
            Cost = model.Cost,
            Supplier = model.Supplier.ToDto(),
            LastUpdated = model.LastUpdated
        };
    }
    public static InventorySupplierDto? ToDto(this InventorySupplier? model)
    {
        if (model is null) return null;

        return new InventorySupplierDto
        {
            Name = model.Name
        };
    }
}