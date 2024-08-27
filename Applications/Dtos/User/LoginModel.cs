using System.ComponentModel.DataAnnotations;

namespace ProjetoClean.WebApi.Models;

public class LoginModel
{
    [Required]
    [EmailAddress(ErrorMessage = " invalido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "invalid")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
