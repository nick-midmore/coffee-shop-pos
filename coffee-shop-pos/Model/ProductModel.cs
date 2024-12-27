using coffee_shop_pos.DataClasses;
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
        => await _context.Products.ToListAsync();

    public Product? GetProductById(int id)
        => _context.Products.FirstOrDefault(x => x.ProductId == id);

    public Product? AddProduct(Product product)
    {
        try
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        catch
        {
            return null;
        }
    }

    public Product? UpdateProduct(Product product, int id)
    {
        try
        {
            var result = GetProductById(id);
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
        var product = GetProductById(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
        else return false;
    }
}
