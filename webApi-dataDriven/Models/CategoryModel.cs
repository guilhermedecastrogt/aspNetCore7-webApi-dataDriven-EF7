using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi_dataDriven.Models;

public class CategoryModel
{
    [Key] public Guid Id { get; set; }
    [Required(ErrorMessage = "Required field")]
    public string Title { get; set; }
}