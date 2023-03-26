namespace backend.Entities;

using System.Text.Json.Serialization;

public class Configuration{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; } = 0.0!;
}