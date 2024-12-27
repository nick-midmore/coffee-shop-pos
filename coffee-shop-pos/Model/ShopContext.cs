using coffee_shop_pos.DataClasses;
using Microsoft.EntityFrameworkCore;

namespace coffee_shop_pos.Model;

public class ShopContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source = products.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductOrder>()
            .HasKey(po => new { po.OrderId, po.ProductId });

        modelBuilder.Entity<ProductOrder>()
            .HasOne(po => po.Order)
            .WithMany(o => o.ProductOrders)
            .HasForeignKey(o => o.OrderId);

        modelBuilder.Entity<ProductOrder>()
            .HasOne(po => po.Product)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(o => o.ProductId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Coffee"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Pastries"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Juice"
                }
            });

        modelBuilder.Entity<Product>()
            .HasData(new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Cappuccino",
                    CategoryId = 1,
                    Price = 3.65m,
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Flat White",
                    CategoryId = 1,
                    Price = 3.80m,
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Esspresso",
                    CategoryId = 1,
                    Price = 3.15m,
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Croissant",
                    CategoryId = 2,
                    Price = 3.55m,
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Pain au Chocolat",
                    CategoryId = 2,
                    Price = 3.79m,
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Orange",
                    CategoryId = 3,
                    Price = 3.10m,
                },
            });
    }
}
