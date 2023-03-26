namespace backend.Entities;

using System.Text.Json.Serialization;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderID { get; set; }
    public int ItemID { get; set; }
    public int Quantity { get; set; }

}