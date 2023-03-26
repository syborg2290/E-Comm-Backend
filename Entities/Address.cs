namespace backend.Entities;

using System.Text.Json.Serialization;

public class Address{
    public int Id { get; set; }
    public string Street_Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Zip_Code { get; set; } = null!;
    public string Country { get; set; } = null!;
}