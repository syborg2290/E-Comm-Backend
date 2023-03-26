namespace backend.Models.Category;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestCategory
{

    [Required]
    public string Name { get; set; } = null!;

}