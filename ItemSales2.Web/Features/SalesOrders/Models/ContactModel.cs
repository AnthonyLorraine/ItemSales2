using System.ComponentModel.DataAnnotations;

namespace ItemSales2.Web.Features.SalesOrders.Models;

public class ContactModel
{
    [Key]
    public int ContactId { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    public string? CompanyName { get; set; }
    public string? PrimaryNumber { get; set; }
    public string? EmailAddress { get; set; }
}