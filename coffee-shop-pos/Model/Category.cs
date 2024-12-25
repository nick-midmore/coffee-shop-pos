using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace coffee_shop_pos.Model;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}