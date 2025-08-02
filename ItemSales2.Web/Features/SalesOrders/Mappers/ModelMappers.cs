using ItemSales2.Web.Features.SalesOrders.Dtos;
using ItemSales2.Web.Features.SalesOrders.Models;
using ItemSales2.Web.Features.SalesOrders.Services;

namespace ItemSales2.Web.Features.SalesOrders.Mappers;

public static class ModelMappers
{
    public static List<ContactSearchResponseDto> ToDto(this List<ContactModel> models)
    {
        return models.Select(ToDto).ToList();
    }
    public static ContactSearchResponseDto ToDto(this ContactModel model)
    {
        return new ContactSearchResponseDto()
        {
            CompanyName = model.CompanyName,
            ContactId = model.ContactId,
            GivenName = model.GivenName,
            Surname = model.Surname
        };
    }
    
    public static List<ItemSearchResponseDto> ToDto(this List<ItemModel> models)
    {
        return models.Select(ToDto).ToList();
    }
    public static ItemSearchResponseDto ToDto(this ItemModel model)
    {
        return new ItemSearchResponseDto()
        {
            ItemId = model.ItemId,
            Sku = model.Sku,
            Description = model.Description,
        };
    }
}
