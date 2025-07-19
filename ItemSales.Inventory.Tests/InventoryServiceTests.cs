using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Dtos.Request;
using ItemSales.Inventory.Services;

namespace ItemSales.Inventory.Tests;

public class InventoryServiceTests
{
    [Fact]
    public async Task CreateNewInventoryItem_Supplier()
    {
        var inventoryService = new InventoryService();
        var createDto = new CreateInventoryItemDto
        {
            Sku = "Item1",
            Description = "Description 1",
            Cost = 1.32m,
            Supplier = new InventorySupplierDto()
            {
                Name = "Supplier 1",
            },
            Location = new InventoryLocationDto()
            {
                IsPrimary = true,
                Name = "Primary Location",
            }
        };
        var inventoryDto = await inventoryService.CreateAsync(createDto);
        Assert.NotNull(inventoryDto);
        Assert.Equal("Item1", inventoryDto.Sku);
        Assert.Equal("Description 1", inventoryDto.Description);
        Assert.NotEmpty(inventoryDto.Prices);
        var price = inventoryDto.Prices.First();
        Assert.NotNull(price.Supplier);
        Assert.Equal(1.32m, price.Cost);
        Assert.Equal("Supplier 1", price.Supplier.Name);
        Assert.NotEmpty(inventoryDto.Locations);
        var location = inventoryDto.Locations.First();
        Assert.Equal("Primary Location", location.Name);
    }
    
    [Fact]
    public async Task CreateNewInventoryItem_NoSupplier()
    {
        var inventoryService = new InventoryService();
        var createDto = new CreateInventoryItemDto
        {
            Sku = "Item1",
            Description = "Description 1",
            Cost = 1.32m,
            Location = new InventoryLocationDto()
            {
                IsPrimary = true,
                Name = "Primary Location",
            }
        };
        var inventoryDto = await inventoryService.CreateAsync(createDto);
        Assert.NotNull(inventoryDto);
        Assert.Equal("Item1", inventoryDto.Sku);
        Assert.Equal("Description 1", inventoryDto.Description);
        Assert.NotEmpty(inventoryDto.Prices);
        var price = inventoryDto.Prices.First();
        Assert.Null(price.Supplier);
        Assert.Equal(1.32m, price.Cost);
        Assert.NotEmpty(inventoryDto.Locations);
        var location = inventoryDto.Locations.First();
        Assert.Equal("Primary Location", location.Name);
    }
}