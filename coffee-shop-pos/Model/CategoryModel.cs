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

    public Category? AddCategory(Category category)
    {
        try
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        catch
        {
            return null;
        }
    }

    public Category? UpdateCategory(Category category, int id)
    {
        var result = GetCategoryById(id);

        if (result != null)
        {
            result.Name = category.Name;
            return result;
        }
        else return null;
    }

    public bool DeleteCategory(int id)
    {
        var result = GetCategoryById(id);
        if (result != null)
        {
            _context.Categories.Remove(result);
            _context.SaveChanges();
            return true;
        }
        else return false;
    }
}