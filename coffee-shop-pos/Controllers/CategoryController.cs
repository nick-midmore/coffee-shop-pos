using coffee_shop_pos.DataClasses;
using coffee_shop_pos.Model;
using Microsoft.AspNetCore.Mvc;

namespace coffee_shop_pos.Controllers;

[Route("api/[controller]")]
public class CategoryController : Controller
{
    private CategoryModel _categoryModel;


    public CategoryController(CategoryModel categoryModel)
        => _categoryModel = categoryModel;

    [HttpGet]
    public ActionResult<List<Category>> GetCategories()
        => Ok(_categoryModel.Index());

    [HttpGet("{id}")]
    public ActionResult<Category> GetCategoryById(int id)
    {
        var category = _categoryModel.GetCategoryById(id);
        return category != null ? Ok(category) : NotFound();
    }

    [HttpPost]
    public ActionResult<Category> AddCategory([FromBody] Category category)
        => category != null ? Ok(category) : BadRequest();

    [HttpPut("{id}")]
    public ActionResult<Category> UpdateCategory([FromBody] Category category, int id)
    {
        var result = _categoryModel.UpdateCategory(category, id);
        if (category != null && result != null) return Ok(result);
        else return BadRequest();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCategory(int id)
    {
        if (_categoryModel.DeleteCategory(id)) return NoContent();
        else return NotFound();
    }
}
