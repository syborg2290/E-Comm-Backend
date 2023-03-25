namespace backend.Entities;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; } = null!;
}