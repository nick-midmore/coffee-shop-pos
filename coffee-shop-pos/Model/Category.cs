using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace coffee_shop_pos.Model;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    [Key]
    [JsonPropertyName("id")]
    public int CategoryId { get; set; }

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();
}