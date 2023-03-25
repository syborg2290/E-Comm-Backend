namespace backend.Models.Users;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequest
{
   
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [EnumDataType(typeof(Role))]
    public string Role { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
}