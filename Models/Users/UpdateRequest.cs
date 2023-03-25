namespace backend.Models.Users;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class UpdateRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    [EnumDataType(typeof(Role))]
    public string Role { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    // treat empty string as null for password fields to 
    // make them optional in front end apps
    private string _password;
    [MinLength(6)]
    public string Password { get; set; } = null!;

    private string _confirmPassword;
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;

    // helpers

    private string replaceEmptyWithNull(string value)
    {
        // replace empty string with null to make field optional
        return string.IsNullOrEmpty(value) ? null : value;
    }
}