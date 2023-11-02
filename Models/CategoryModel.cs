using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi_dataDriven.Models;

public class CategoryModel
{
    [Key] public int Id { get; set; } //= Guid.NewGuid();
    [Required(ErrorMessage = "Required field")]
    public string Title { get; set; }
}