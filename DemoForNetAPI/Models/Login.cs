using System.ComponentModel.DataAnnotations;

namespace DemoForNetAPI.Models;

public class Login
{
    [EmailAddress]
    public string Email { get; set; }
    [Required, MinLength(8)]
    public string Password { get; set; }
}