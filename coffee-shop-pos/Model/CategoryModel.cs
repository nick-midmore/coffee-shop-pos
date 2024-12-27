
using coffee_shop_pos.DataClasses;

namespace coffee_shop_pos.Model;

public class CategoryModel
{
    private readonly ShopContext _context;

    public CategoryModel(ShopContext context)
        => _context = context;

    public List<Category> Index()
        => _context.Categories.ToList();

    public Category? GetCategoryById(int id)
        => _context.Categories.FirstOrDefault(c => c.CategoryId == id);
}