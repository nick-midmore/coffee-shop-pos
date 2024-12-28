namespace coffee_shop_pos.DataClasses;

public class Order
{
    public int OrderId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
}
