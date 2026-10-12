namespace UnitConverter.Models;

using System.Text.Json.Serialization;

public class LogEntry
{
    [JsonPropertyName("@t")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("@l")]
    public string? Level { get; set; } = "Information";

    [JsonPropertyName("@m")]
    public string? Message { get; set; } = string.Empty;

    [JsonPropertyName("@x")]
    public string? Exception { get; set; } = string.Empty;

    public decimal Input { get; set; } = 0;
    public string? ConversionType { get; set; } = string.Empty;
    public decimal? Result { get; set; } = 0;


}
