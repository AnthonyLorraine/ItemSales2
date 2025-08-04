using ItemSales2.Web.Features.SalesOrders.Dtos;
using ItemSales2.Web.Features.SalesOrders.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemSales2.Web.Features.SalesOrders.Controllers;

public class SalesOrderController : Controller
{
    private readonly SalesOrderService _orderService;
    public SalesOrderController(SalesOrderService orderService)
    {
        _orderService = orderService;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateSalesOrderDto dto, CancellationToken ct)
    {
        var validCustomer = await _orderService.ValidateCustomer(dto, ct);
        if (!validCustomer)
        {
            return BadRequest("Invalid customer");
        }
        var salesOrderId = await _orderService.CreateSalesOrder(dto, ct);
        return Json(salesOrderId);
    }

    public async Task<IActionResult> SearchCustomers(string searchQuery, CancellationToken ct)
    {
        var customers = await _orderService.SearchCustomersAsync(searchQuery, ct);
        return Json(customers);
    }

    public async Task<IActionResult> GetSalesOrder(int salesOrderId, CancellationToken ct)
    {
        var salesOrder = await _orderService.GetSalesOrderById(salesOrderId, ct); 
        return Json(salesOrder);
    }

    public IActionResult AddOrderItem()
    {
        throw new NotImplementedException();
    }

    public IActionResult RemoveOrderItem()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> SearchItems(string searchQuery, CancellationToken ct)
    {
        var items = await _orderService.SearchItemsAsync(searchQuery, ct);
        return Json(items);
    }
}