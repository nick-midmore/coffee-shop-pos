

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
    public List<Product> Index()
    {
        return new List<Product>();
    }

    internal object? GetProductById()
    {
        throw new NotImplementedException();
    }
    public Product? AddProduct(JsonObject productJson)
    {
        try
        {
            var p = JsonSerializer.Deserialize<Product>(productJson);
            _context.Products.Add(p);
            _context.SaveChanges();
            return p;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}