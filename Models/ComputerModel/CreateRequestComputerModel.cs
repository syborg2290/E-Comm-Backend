namespace backend.Models.ComputerModel;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestComputerModel
{

    [Required]
    public string Model_Name { get; set; } = null!;
    [Required]
    public int SeriesId { get; set; }
    [Required]
    public int Default_Configuration_ID { get; set; }

}