using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using UnitConverter.Pages;
using UnitConverter.Models;


namespace UnitConverter;

public class Conversions : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Output { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; }

    public string InputType = string.Empty;

    public string OutputType = string.Empty;

    [BindProperty(SupportsGet = true)] public ConversionModel Conversion { get; set; } = new ConversionModel();

    public Conversions()
    {
        Input = string.Empty;
        Output = string.Empty;
        ConversionType = string.Empty;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Conversions";

        //Boolean conversionError = false;

        // This keeps the default behavior from Lesson 1
        if (string.IsNullOrEmpty(Conversion.ConversionType))
        {
            Conversion.ConversionType = ConversionTypes.MilesToKilometers;
            Conversion.Input = 3.1415.ToString();
        }

        if (string.IsNullOrEmpty(ConversionType) && string.IsNullOrEmpty(Input))
        {
            ConversionType = Conversion.ConversionType;
            Input = Conversion.Input;
        }

        double inputConversion = 0;

        //Checks for input error. Catches it if it happens to stop it from crashing.
        try
        {
            inputConversion = Convert.ToDouble(Input);
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid input: must be a number. " + e.Message);
            ViewData["ErrorMessage"] = "Input must be a number. Try again.";
            return;
        }


        //line below will represent the new, converted input
        double result = 0;

        /*Takes a conversion type and input given. Converts input based on conversion type.
         If the conversion type is invalid or unsupported, a warning will show.*/
        if (ConversionType == ConversionTypes.MilesToKilometers)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.MilesToKilometers];
            //next 2 lines below takes inputConversion and turns it from miles to kilometers
            UnitOf.Length unit = new UnitOf.Length().FromMiles(inputConversion);
            result = unit.ToKilometers();
            result = Math.Abs(result);

            InputType = "miles";
            OutputType = "Kilometers";
        }
        else if(ConversionType == ConversionTypes.KilometersToMiles)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.KilometersToMiles];
            //next 2 lines below takes inputConversion and turns it from kilometers to miles
            UnitOf.Length unit = new UnitOf.Length().FromKilometers(inputConversion);
            result = unit.ToMiles();
            result = Math.Abs(result);

            InputType = "kilometers";
            OutputType = "miles";
        }
        else if (ConversionType == ConversionTypes.FahrenheitToCelsius)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.FahrenheitToCelsius];
            //next 2 lines below takes inputConversion and turns it from Fahrenheit to Celsius
            UnitOf.Temperature unit = new UnitOf.Temperature().FromFahrenheit(inputConversion);
            result = unit.ToCelsius();

            InputType = "Fahrenheit";
            OutputType = "Celsius";
        }
        else if (ConversionType == ConversionTypes.CelsiusToFahrenheit)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.CelsiusToFahrenheit];
            //next 2 lines below takes inputConversion and turns it from Celsius to Fahrenheit
            UnitOf.Temperature unit = new UnitOf.Temperature().FromCelsius(inputConversion);
            result = unit.ToFahrenheit();

            InputType = "Celsius";
            OutputType = "Fahrenheit";
        }
        else if (ConversionType == ConversionTypes.PoundsToKilograms)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.PoundsToKilograms];
            //next 2 lines below takes inputConversion and turns it from pounds to kilograms
            UnitOf.Mass unit = new UnitOf.Mass().FromPounds(inputConversion);
            result = unit.ToKilograms();
            result = Math.Abs(result);

            InputType = "pounds";
            OutputType = "kilograms";
        }
        else if (ConversionType == ConversionTypes.KilogramsToPounds)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.KilogramsToPounds];
            //next 2 lines below takes inputConversion and turns it from kilograms to pounds
            UnitOf.Mass unit = new UnitOf.Mass().FromKilograms(inputConversion);
            result = unit.ToPounds();
            result = Math.Abs(result);

            InputType = "kilograms";
            OutputType = "pounds";
        }
        else if (ConversionType == ConversionTypes.BitsToBytes)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.BitsToBytes];
            //next 2 lines below takes inputConversion and turns it from bytes to gigabytes
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBits(inputConversion);
            result = unit.ToBytes();
            result = Math.Abs(result);

            InputType = "bits";
            OutputType = "bytes";
        }
        else if (ConversionType == ConversionTypes.BytesToBits)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.BytesToBits];
            //next 2 lines below takes inputConversion and turns it from gigabytes to bytes
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBytes(inputConversion);
            result = unit.ToBits();
            result = Math.Abs(result);

            InputType = "bytes";
            OutputType = "bits";
        }
        else if (ConversionType == ConversionTypes.MinutesToHours)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.MinutesToHours];
            //next 2 lines below takes inputConversion and turns it from minutes to hours
            UnitOf.Time unit = new UnitOf.Time().FromMinutes(inputConversion);
            result = unit.ToHours();
            result = Math.Abs(result);

            InputType = "minutes";
            OutputType = "hours";
        }
        else if (ConversionType == ConversionTypes.HoursToMinutes)
        {
            ViewData["ConversionType"] = ConversionTypes.All[ConversionTypes.HoursToMinutes];
            //next 2 lines below takes inputConversion and turns it from hours to minutes
            UnitOf.Time unit = new UnitOf.Time().FromHours(inputConversion);
            result = unit.ToMinutes();
            result = Math.Abs(result);

            InputType = "hours";
            OutputType = "minutes";
        }
        else
        {
            /* This is designed to catch errors in the conversionType part.
             View Data for Conversion Type is set to blank. */
            ViewData["ErrorMessage"] = "Unknown or unsupported conversion type. Try again.";
            ViewData["ConversionType"] = "";
            Conversion.Input = "";
            Conversion.Output = "";

            InputType = "";
            OutputType = "";
        }

        //line below takes newInput and rounds it.
        result = Math.Round(result, 4);
        //line below takes newInput and gives it to Output as a string
        Conversion.Output = result.ToString();
        Input = Conversion.Input;
        Output = Conversion.Output;
    }




}
