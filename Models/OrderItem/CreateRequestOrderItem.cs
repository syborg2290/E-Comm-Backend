namespace backend.Models.OrderItem;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestOrderItem
{

    [Required]
    public int OrderID { get; set; }

    [Required]
    public int ItemID { get; set; }

    [Required]
    public int Quantity { get; set; }

}