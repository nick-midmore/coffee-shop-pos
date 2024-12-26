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

    public Product? GetProductById(int id)
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

    public Product? UpdateProduct(Product product, int id)
    {
        try
        {
            var result = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (result != null)
            {
                result.Name = product.Name;
                result.Price = product.Price;
                result.CategoryId = product.CategoryId;

                _context.SaveChanges();
                return result;
            }
            else return null;
        }
        catch
        {
            return null;
        }
    }

    public bool DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
        else return false;
    }
}
