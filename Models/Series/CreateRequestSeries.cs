namespace backend.Models.Series;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestSeries
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int CategoryID { get; set; }

}