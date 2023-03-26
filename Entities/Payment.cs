namespace backend.Entities;

using System.Text.Json.Serialization;

public class Payment
{
    public int Id { get; set; }
    public int OrderID { get; set; }
    public double Amount { get; set; } = 0.0!;
    public string PaymentDate { get; set; } = null!;

}