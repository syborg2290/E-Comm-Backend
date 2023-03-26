namespace backend.Models.Customer;

using System.ComponentModel.DataAnnotations;

public class CreateRequestCustomer
{
   
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Phone_Number { get; set; } = null!;

    //Billing address details

    [Required]
    public string Street_Address_billing { get; set; } = null!;
    [Required]
    public string City_billing { get; set; } = null!;
    [Required]
    public string State_billing { get; set; } = null!;
    [Required]
    public string Zip_Code_billing { get; set; } = null!;
    [Required]
    public string Country_billing { get; set; } = null!;

    
     //Shipping address details

    [Required]
    public string Street_Address_shipping { get; set; } = null!;
    [Required]
    public string City_shipping { get; set; } = null!;
    [Required]
    public string State_shipping { get; set; } = null!;
    [Required]
    public string Zip_Code_shipping { get; set; } = null!;
    [Required]
    public string Country_shipping { get; set; } = null!;
 
}