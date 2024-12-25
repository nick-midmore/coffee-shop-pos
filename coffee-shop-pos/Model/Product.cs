using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coffee_shop_pos.Model;

[Index(nameof(Name), IsUnique = true)]
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
}