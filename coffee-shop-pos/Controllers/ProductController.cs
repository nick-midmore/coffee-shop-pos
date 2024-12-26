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
    public ActionResult<Product> AddProduct([FromBody]JsonObject productJson)
    {
        var product = _productModel.AddProduct(productJson);
        if (product != null)
        {
            return Ok(product);
        }
        else return BadRequest();
    }
}
