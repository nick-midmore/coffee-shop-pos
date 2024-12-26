using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace coffee_shop_pos.Model;

public class ProductModel
{
    private readonly ShopContext _context;
    public ProductModel(ShopContext shopContext)
    {
        _context = shopContext;
    }
    public async Task<List<Product>> Index()
    {
        return await _context.Products
            .Include(x => x.Category)
            .ToListAsync();
    }

    internal Product? GetProductById(int id)
    {
        try
        {
            return _context.Products
                .Include(x => x.Category)
                .FirstOrDefault(x => x.ProductId == id);
        }
        catch
        {
            return null;
        }
    }
    public Product? AddProduct(Product product)
    {
        try
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}