using System.Text.Json.Serialization;
namespace UnitConverter.Models;


/**
 * This class sets up the json variables (timestamp, message, level, ect.) to help
 * log conversions that happen from the QuickConversions Page.
 */
public class LogEntry
{
    [JsonPropertyName("@t")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("@m")]
    public string? Message { get; set; } = string.Empty;

    [JsonPropertyName("@l")]
    public string? Level { get; set; } = "Information";

    [JsonPropertyName("@x")]
    public string? Exception { get; set; } = string.Empty;

    public decimal Input { get; set; } = 0;
    public string? ConversionType { get; set; } = string.Empty;
    public decimal Result { get; set; } = 0;
}
