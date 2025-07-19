using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Models;

namespace ItemSales.Inventory.Mappers;

public static class ModelMapper
{
    public static InventoryLocation ToModel(this InventoryLocationDto dto)
    {
        return new InventoryLocation
        {
            Name = dto.Name,
            IsPrimary = dto.IsPrimary
        };
    }

    public static InventoryPricing ToModel(this InventoryItemPricingDto dto)
    {
        return new InventoryPricing
        {
            Cost = dto.Cost,
            Supplier = dto.Supplier.ToModel(),
            LastUpdated = dto.LastUpdated
        };
    }

    public static InventorySupplier? ToModel(this InventorySupplierDto? dto)
    {
        if (dto is null) return null;

        return new InventorySupplier
        {
            Name = dto.Name
        };
    }
}