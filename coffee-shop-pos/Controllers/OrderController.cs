using coffee_shop_pos.DataClasses;
using coffee_shop_pos.DataClasses.DTO;
using coffee_shop_pos.Model;
using Microsoft.AspNetCore.Mvc;

namespace coffee_shop_pos.Controllers;

[Route("api/[controller]")]
public class OrderController :Controller
{
    private readonly OrderModel _orderModel;

    public OrderController(OrderModel orderModel)
        => _orderModel = orderModel;

    //[HttpGet]
    //public ActionResult<List<Order>> Index()
    //    => Ok(_orderModel.Index());

    //[HttpGet("{id}")]
    //public ActionResult<Order> GetOrderById(int id)
    //{
    //    var order = _orderModel.GetOrderById(id);
    //    return order != null ? Ok(order) : BadRequest();
    //}

    [HttpPost]
    public ActionResult<Order> AddOrder([FromBody]List<ProductOrderDto> orders)
    {
        var order = _orderModel.AddOrder(orders);
        return order == null ? Ok(order) : BadRequest();
    }
}
