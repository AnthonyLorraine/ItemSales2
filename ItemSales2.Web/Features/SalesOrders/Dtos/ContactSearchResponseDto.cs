namespace ItemSales2.Web.Features.SalesOrders.Dtos;

public class ContactSearchResponseDto
{
    public int ContactId { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    public string? CompanyName { get; set; }
}