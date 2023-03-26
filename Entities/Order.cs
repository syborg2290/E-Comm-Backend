namespace backend.Entities;

using System.Text.Json.Serialization;

public class Order{
    public int Id { get; set; }
    public int CustomerID { get; set; }
    public int ShippingAddressID { get; set; }
    public int BillingAddressID { get; set; }
    public string Shipping_Method { get; set; } = null!;
    public string Shipping_Date { get; set; } = null!;
    public double TotalPrice { get; set; } = 0.0!;
    public string OrderStatus { get; set; } = null!;
}