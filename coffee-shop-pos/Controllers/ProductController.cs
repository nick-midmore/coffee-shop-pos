using coffee_shop_pos.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace coffee_shop_pos.Controllers;

[Route("api/products")]
public class ProductController : Controller
{
    private ProductModel _productModel;

    public ProductController(ProductModel productModel)
    { _productModel = productModel; }

    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return Ok(_productModel.Index());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _productModel.GetProductById(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        if (product != null)
        {
            return Ok(_productModel.AddProduct(product));
        }
        else return BadRequest();
    }

    [HttpPut("{id}")]
    public ActionResult<Product> UpdateProduct([FromBody] Product product, int id)
    {
        var result = _productModel.UpdateProduct(product, id);
        if (product != null && result != null) return Ok(result);
        else return BadRequest();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        if (_productModel.DeleteProduct(id)) return NoContent();
        else return NotFound();
    }
}
