namespace backend.Models.Order;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestOrder
{

    [Required]
    public int CustomerID { get; set; }

    [Required]
    public int ShippingAddressID { get; set; }

    [Required]
    public int BillingAddressID { get; set; }

    [Required]
    public string Shipping_Method { get; set; } = null!;

    [Required]
    public string Shipping_Date { get; set; } = null!;

    [Required]
    public double TotalPrice { get; set; } = 0.0!;

    [Required]
    public string OrderStatus { get; set; } = null!;

}