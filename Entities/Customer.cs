namespace backend.Entities;

using System.Text.Json.Serialization;

public class Customer{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone_Number { get; set; } = null!;
    public int Billing_Address_ID { get; set; }
    public int Shipping_Address_ID { get; set; }
}