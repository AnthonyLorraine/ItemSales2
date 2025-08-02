using ItemSales2.Web.Features.SalesOrders.Data;
using ItemSales2.Web.Features.SalesOrders.Services;
using ItemSales2.Web.WebConfiguration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<SalesOrderService>();

// Check feature folder for views and controllers
builder.Services
    .AddControllersWithViews(options => options.Conventions.Add(new FeatureControllerModelConvention())) 
    .AddRazorOptions(options => options.ViewLocationExpanders.Add(new FeatureViewLocationExpander()))
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

builder.Services.AddDbContext<SalesOrderContext>(o =>
{
    o.UseSqlite("Datasource=app.sqlite");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SalesOrder}/{action=Index}/{id?}");

app.Run();