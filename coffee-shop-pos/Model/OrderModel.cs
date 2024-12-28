using coffee_shop_pos.DataClasses;

namespace coffee_shop_pos.Model;

public class OrderModel
{
    private readonly ShopContext _context;
    
    public OrderModel(ShopContext shopContext)
        => _context = shopContext;

    public Order? AddOrder(List<ProductOrder> orders)
    {
        if (orders.GroupBy(x => x.OrderId).Count() != 1 ||
            orders == null ||
            orders.Count == 0) return null;

        var newOrder = new Order();
        _context.Orders.Add(newOrder);
        _context.SaveChanges();

        foreach (var order in orders)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == order.ProductId);
            if (product == null) return null;
            order.Order = newOrder;
            order.Product = product;

            newOrder.TotalPrice += order.Product.Price * order.Quantity;
            newOrder.ProductOrders.Add(order);
        }

        _context.ProductOrders.AddRange(orders);
        _context.SaveChanges();
        return newOrder;
    }
}