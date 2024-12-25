using coffee_shop_pos.Model;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<Product> GetProductById()
    {
        return Ok(_productModel.GetProductById());
    }

    [HttpPost]
    public ActionResult<Product> AddProduct()
    {
        return Ok(new Product());

    }
}
