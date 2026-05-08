using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WarehouseContext>(options =>
    options.UseSqlite(connection));

builder.Services.AddScoped<IWarehouseService, WarehouseService>();

var app = builder.Build();

app.MapGet("/api/items", async (WarehouseContext db) =>
{
    return await db.Items.ToListAsync();
});

app.MapGet("/api/items/{id}/format", async (
    WarehouseContext db,
    IWarehouseService service,
    int id) =>
{
    var item = await db.Items.FindAsync(id);
    if (item == null) return Results.NotFound();

    var formatted = service.FormatItem(item);
    return Results.Ok(new { message = formatted });
});

app.MapGet("/api/config", (IConfiguration config) =>
{
    return new
    {
        appName = config["AppName"],
        version = config["Version"]
    };
});
app.MapGet("/", () => "Warehouse API запущен! Используйте /api/items чтобы получить данные.");
app.Run();




