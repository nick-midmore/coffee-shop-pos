using coffee_shop_pos.DataClasses;
using coffee_shop_pos.DataClasses.DTO;

namespace coffee_shop_pos.Model;

public class OrderModel
{
    private readonly ShopContext _context;
    private readonly ProductModel _productModel;
    
    public OrderModel(ShopContext shopContext, ProductModel productModel)
    {
        _context = shopContext;
        _productModel = productModel;
    }    

    public Order? AddOrder(List<ProductOrderDto> orders)
    {
        if (orders == null || orders.Count == 0)
        {
            return null;
        }

        var newOrder = new Order();
        newOrder.CreatedAt = DateTime.Now;

        foreach (var orderDto in orders)
        {
            var product = _productModel.GetProductById(orderDto.ProductId);
            if (product == null) return null;

            var productOrder = new ProductOrder
            {
                Order = newOrder,
                ProductId = orderDto.ProductId,
                Product = product,
                Quantity = orderDto.Quantity
            };

            newOrder.TotalPrice += productOrder.Product.Price * orderDto.Quantity;
            newOrder.ProductOrders.Add(productOrder);
            _context.ProductOrders.Add(productOrder);
        }

        _context.Orders.Add(newOrder);
        _context.SaveChanges();
        return newOrder;
    }
}