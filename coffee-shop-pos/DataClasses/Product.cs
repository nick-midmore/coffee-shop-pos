using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace coffee_shop_pos.DataClasses;

public class Product
{
    [JsonPropertyName("id")]
    public int ProductId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public ICollection<ProductOrder> ProductOrders { get; set; }
}