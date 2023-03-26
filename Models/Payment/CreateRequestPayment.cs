namespace backend.Models.Payment;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestPayment
{

    [Required]
    public int OrderID { get; set; }

    [Required]
    public double Amount { get; set; } = 0.0!;

    [Required]
    public string PaymentDate { get; set; } = null!;

}