using System.Net.Http.Json;
using ItemSales.Inventory.Dtos;
using ItemSales.Inventory.Dtos.Request;

namespace ItemSales.Web.Client.Services;

public class InventoryService
{
    private readonly HttpClient _httpClient;
    public InventoryService([FromKeyedServices("api")]HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<InventoryItemDto?> CreateInventoryItem(CreateInventoryItemDto item)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/v1/Inventory", item);
        response.EnsureSuccessStatusCode();
        var newItem = await response.Content.ReadFromJsonAsync<InventoryItemDto>();
        return newItem;
    }
    
    public async Task<InventoryItemDto?> GetInventoryItem(int itemId)
    {
        var newItem = await _httpClient.GetFromJsonAsync<InventoryItemDto>($"/api/v1/Inventory/{itemId}");
        return newItem;
    }
}