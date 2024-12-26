

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
        return _context.Products.ToList();
    }

    internal Product? GetProductById(int id)
    {
        try
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);
        }
        catch
        {
            return null;
        }
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