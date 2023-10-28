using System.ComponentModel.DataAnnotations;

namespace webApi_dataDriven.Models;

public class UserModel
{
    [Key] public int Id { get; set; }
    
    [Required(ErrorMessage = "Required field")]
    [MaxLength(20, ErrorMessage = "A field should contain a maximum 20 characters")]
    [MinLength(3, ErrorMessage = "A field should contain a minimum 3 characters")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Required field")]
    [MaxLength(20, ErrorMessage = "A field should contain a maximum 20 characters")]
    [MinLength(3, ErrorMessage = "A field should contain a maximum 3 characters")]
    public string Password { get; set; }

    public string Role { get; set; }
}