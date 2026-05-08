using Microsoft.EntityFrameworkCore;

public class WarehouseContext : DbContext
{
    public WarehouseContext(DbContextOptions<WarehouseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<WarehouseItem> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WarehouseItem>().HasData(
            new WarehouseItem { Id = 1, Name = "Ноутбук", Quantity = 10, Price = 50000 },
            new WarehouseItem { Id = 2, Name = "Мышка", Quantity = 50, Price = 1500 },
            new WarehouseItem { Id = 3, Name = "Клавиатура", Quantity = 30, Price = 3000 }
        );
    }
}


