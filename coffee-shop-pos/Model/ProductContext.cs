using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace coffee_shop_pos.Model;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source = products.db");

}
