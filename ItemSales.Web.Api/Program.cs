using System.Reflection;
using FluentValidation;
using ItemSales.Inventory.Services;
using ItemSales.Web.Api;
using ItemSales.Web.Api.Middleware;
using ItemSales.Web.Api.Setup;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.UseNLog();
builder.Services.AddMemoryCache();
builder.Services.AddCors();
builder.Services.AddSingleton<ApplicationDetails>();
builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddExceptionHandler<Server500ProblemExceptionHandler>();
builder.Services.AddHealthChecks().AddCheck<ApplicationHealthCheck>("Api");
builder.Services.AddCustomApiVersioning();
builder.Services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();
builder.Services.AddCustomProblemDetails();
builder.Services.AddSwaggerGen();

// Core App Services
builder.Services.AddScoped<IInventoryService, InventoryService>();

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseMiddleware<ValidationMappingMiddleware>();
app.UseCors(o =>
{
    o.AllowAnyOrigin();
    o.AllowAnyHeader();
    o.AllowAnyMethod();
});
app.UseHttpsRedirection();
app.ConfigureEndpointRoutes();
app.Run();