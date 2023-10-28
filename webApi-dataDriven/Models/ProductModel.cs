using System.ComponentModel.DataAnnotations;

namespace webApi_dataDriven.Models;

public class ProductModel
{
    [Key] public Guid Id { get; set; }
    
    [MaxLength(30, ErrorMessage = "A field should contain a maximum of 30 characters")]
    [MinLength(3, ErrorMessage = "A field should contain a minimum 3 characters")]
    public string Title { get; set; }
    
    [MaxLength(1024, ErrorMessage = "A field should contain a maximum of 1024 characters")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Required field")]
    [Range(1, int.MaxValue, ErrorMessage = "A price should be greather than zero")]
    public decimal Price { get; set; }

    public CategoryModel Category { get; set; }
}