namespace backend.Models.DefaultConfiguration;

using System.ComponentModel.DataAnnotations;
using backend.Entities;

public class CreateRequestDefaultConfiguration
{

    [Required]
    public int ConfigurationID { get; set; }

}