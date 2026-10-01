using Microsoft.AspNetCore.Components.Forms;
using UnitConverter.Models;


namespace UnitConverter;

public class UnitOfConversionService : IConversionService
{
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



        value = System.Convert.ToDecimal(conversionValue);

        return value;
    }

}
