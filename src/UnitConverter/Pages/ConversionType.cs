namespace UnitConverter.Pages;

public static class ConversionTypes
{
    public const string MilesToKilometers = "MilesToKilometers";
    public const string KilometersToMiles = "KilometersToMiles";
    public const string FahrenheitToCelsius = "FahrenheitToCelsius";
    public const string CelsuiusToFahrenheit = "CelsuiusToFahrenheit";
    public const string PoundsToKilograms = "PoundsToKilograms";
    public const string KilogramsToPounds = "KilogramsToPounds";
    public const string BitsToBytes = "BitsToBytes";
    public const string BytesToBits = "BytesToBits";
    public const string MinutesToHours = "MinutesToHours";
    public const string HoursToMinutes = "HoursToMinutes";

    public static readonly IReadOnlyDictionary<string, string> All =
        new Dictionary<string, string>()
        {
            [MilesToKilometers] = "Miles to Kilometers",
            [KilometersToMiles] = "Kilometers to Miles",
            [FahrenheitToCelsius] = "Fahrenheit to Celsius",
            [CelsuiusToFahrenheit] = "Celsius to Fahrenheit",
            [PoundsToKilograms] = "Pounds to Kilograms",
            [KilogramsToPounds] = "Kilograms to Pounds",
            [BitsToBytes] = "Bits to Bytes",
            [BytesToBits] = "Bytes to Bits",
            [MinutesToHours] = "Minutes to Hours",
            [HoursToMinutes] = "Hours to Minutes"
        };

}
