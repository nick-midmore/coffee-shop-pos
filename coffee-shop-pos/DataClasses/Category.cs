using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace coffee_shop_pos.DataClasses;

public class Category
{
    [JsonPropertyName("id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();
}