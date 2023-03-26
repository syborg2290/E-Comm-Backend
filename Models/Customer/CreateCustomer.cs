namespace backend.Models.Customer;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateCustomer
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Phone_Number { get; set; } = null!;

    [Required]
    public int Billing_Address_ID { get; set; }

    [Required]
    public int Shipping_Address_ID { get; set; }

    
}