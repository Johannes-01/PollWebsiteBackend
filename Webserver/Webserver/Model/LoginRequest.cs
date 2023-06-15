using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
    [Key, Required]
    public int LoginId { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
