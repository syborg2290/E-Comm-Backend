namespace backend.Entities;

using System.Text.Json.Serialization;

public class ComputerModel{
    public int Id { get; set; }
    public string Model_Name { get; set; } = null!;
    public int SeriesId { get; set; }
    public int Default_Configuration_ID { get; set; }
}