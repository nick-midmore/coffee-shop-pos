

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
}