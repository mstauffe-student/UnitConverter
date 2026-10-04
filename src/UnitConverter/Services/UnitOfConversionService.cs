using Microsoft.AspNetCore.Components.Forms;
using UnitConverter.Models;


namespace UnitConverter;

public class UnitOfConversionService : IConversionService
{
    /**
     * Takes a decimal and a string and puts in a big if/else. The decimal gets converted based on the
     * type of conversion wanted. The string represents the type of conversion
     * wanted. Returns the converted value.
     */
    public decimal Convert(decimal value, string conversionType)
    {

        double conversionValue = System.Convert.ToDouble(value);

        if (conversionType == ConversionTypes.MilesToKilometers)
        {
            UnitOf.Length unit = new UnitOf.Length().FromMiles(conversionValue);
            conversionValue = unit.ToKilometers();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }
        if (conversionType == ConversionTypes.KilometersToMiles)
        {
            UnitOf.Length unit = new UnitOf.Length().FromKilometers(conversionValue);
            conversionValue = unit.ToMiles();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }
        if (conversionType == ConversionTypes.FahrenheitToCelsius)
        {
            UnitOf.Temperature unit = new UnitOf.Temperature().FromFahrenheit(conversionValue);
            conversionValue = unit.ToCelsius();
        }
        if (conversionType == ConversionTypes.CelsiusToFahrenheit)
        {
            UnitOf.Temperature unit = new UnitOf.Temperature().FromCelsius(conversionValue);
            conversionValue = unit.ToFahrenheit();
        }
        if (conversionType == ConversionTypes.PoundsToKilograms)
        {
            UnitOf.Mass unit = new UnitOf.Mass().FromPounds(conversionValue);
            conversionValue = unit.ToKilograms();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }
        if (conversionType == ConversionTypes.KilogramsToPounds)
        {
            UnitOf.Mass unit = new UnitOf.Mass().FromKilograms(conversionValue);
            conversionValue = unit.ToPounds();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }
        if (conversionType == ConversionTypes.BitsToBytes)
        {
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBits(conversionValue);
            conversionValue = unit.ToBytes();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }
        if (conversionType == ConversionTypes.BytesToBits)
        {
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBytes(conversionValue);
            conversionValue = unit.ToBits();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }
        if (conversionType == ConversionTypes.MinutesToHours)
        {
            UnitOf.Time unit = new UnitOf.Time().FromMinutes(conversionValue);
            conversionValue = unit.ToHours();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }
        if (conversionType == ConversionTypes.HoursToMinutes)
        {
            UnitOf.Time unit = new UnitOf.Time().FromHours(conversionValue);
            conversionValue = unit.ToMinutes();
            if (conversionValue < 0)
            {
                conversionValue *= -1;
            }
        }

        //line below takes conversionValue and rounds it.
        conversionValue = Math.Round(conversionValue, 4);
        //line below takes conversionValue and gives it to value as a decimal

        value = System.Convert.ToDecimal(conversionValue);

        return value;
    }

    /*
     * Takes a string that represents a type of conversion. It then
     * determines the output "type" based on it. For example, for "miles
     * to kilometers", a converted value would be in "kilometers."
     */
    public string OutputType(string conversionType)
    {
        string outputType = "";
         if (conversionType == ConversionTypes.MilesToKilometers)
        {
            outputType = "kilometers";
        }
        if (conversionType == ConversionTypes.KilometersToMiles)
        {
            outputType = "miles";
        }
        if (conversionType == ConversionTypes.FahrenheitToCelsius)
        {
            outputType = "celsius";
        }
        if (conversionType == ConversionTypes.CelsiusToFahrenheit)
        {
            outputType = "fahrenheit";
        }
        if (conversionType == ConversionTypes.PoundsToKilograms)
        {
           outputType = "kilograms";
        }
        if (conversionType == ConversionTypes.KilogramsToPounds)
        {
           outputType = "pounds";
        }
        if (conversionType == ConversionTypes.BitsToBytes)
        {
           outputType = "bytes";
        }
        if (conversionType == ConversionTypes.BytesToBits)
        {
            outputType  = "bits";
        }
        if (conversionType == ConversionTypes.MinutesToHours)
        {
            outputType = "hours";
        }
        if (conversionType == ConversionTypes.HoursToMinutes)
        {
            outputType = "minutes";
        }

        return outputType;
    }
}
