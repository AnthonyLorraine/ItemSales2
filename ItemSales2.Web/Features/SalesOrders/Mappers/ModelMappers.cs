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
    public static List<SalesOrderItemResponseDto> ToDto(this List<OrderItemModel> models, PricingModel pricing)
    {
        return models.Select(i => i.ToDto(pricing)).ToList();
    }
    public static SalesOrderItemResponseDto ToDto(this OrderItemModel model, PricingModel pricing)
    {
        var priceMatrix = pricing.Matrix
            .FirstOrDefault(m => 
                m.StartPrice >= model.Item.Cost &&
                m.EndPrice <= model.Item.Cost);

        if (priceMatrix == null)
        {
            throw new Exception("Pricing matrix not found");
        }
        
        return new SalesOrderItemResponseDto()
        {
            ItemId = model.ItemId,
            Sku = model.Item.Sku,
            Description = model.Item.Description,
            Price = (model.Item.Cost * priceMatrix.Markup) * 100,
            Quantity = model.Quantity
        };
    }

    public static SalesOrderDto ToDto(this SalesOrderModel model)
    {
        return new SalesOrderDto
        {
            SalesOrderId = model.SalesOrderId,
            Customer = model.Customer.ToDto(),
            Items = model.Items.ToDto(model.Customer.Pricing)
        };
    }
}
