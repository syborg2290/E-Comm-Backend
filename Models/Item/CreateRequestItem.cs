namespace backend.Models.Item;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestItem
{

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int ConfigurationID { get; set; }

}