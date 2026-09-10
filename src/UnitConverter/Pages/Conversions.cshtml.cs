using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UnitConverter;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;

    public string InputType = string.Empty;

    public string OutputType = string.Empty;


    public void OnGet(string input, string conversionType)
    {
        ViewData["Title"] = "Conversions";

        Boolean error = false;
        ViewData["ErrorMessage"] = string.Empty;

        Input = input;
        double inputConversion = 0;

        try
        {
            inputConversion = Convert.ToDouble(Input);
        }
        catch (Exception e)
        {
            error = true;
            Input = "0";
            Console.WriteLine("Invalid input: must be a number. " + e.Message);
        }


        //line below tranforms Input into a double
        double newInput = 0;

        if (conversionType.ToLower() == "milestokilometers")
        {
            ViewData["ConversionType"] = "Miles to Kilometers";
            //next 2 lines below takes inputConversion and turns it from miles to kilometers
            UnitOf.Length unit = new UnitOf.Length().FromMiles(inputConversion);
            newInput = unit.ToKilometers();

            InputType = "miles";
            OutputType = "Kilometers";
        }
        else if(conversionType.ToLower() == "kilometerstomiles")
        {
            ViewData["ConversionType"] = "Kilometers to Miles";
            //next 2 lines below takes inputConversion and turns it from kilometers to miles
            UnitOf.Length unit = new UnitOf.Length().FromKilometers(inputConversion);
            newInput = unit.ToMiles();

            InputType = "kilometers";
            OutputType = "miles";
        }
        else if (conversionType.ToLower() == "fahrenheittocelsius")
        {
            ViewData["ConversionType"] = "Fahrenheit To Celsius";
            //next 2 lines below takes inputConversion and turns it from Fahrenheit to Celsius
            UnitOf.Temperature unit = new UnitOf.Temperature().FromFahrenheit(inputConversion);
            newInput = unit.ToCelsius();

            InputType = "Fahrenheit";
            OutputType = "Celsius";
        }
        else if (conversionType.ToLower() == "celsiustofahrenheit")
        {
            ViewData["ConversionType"] = "Celsius to Fahrenheit";
            //next 2 lines below takes inputConversion and turns it from Celsius to Fahrenheit
            UnitOf.Temperature unit = new UnitOf.Temperature().FromCelsius(inputConversion);
            newInput = unit.ToFahrenheit();

            InputType = "Celsius";
            OutputType = "Fahrenheit";
        }
        else if (conversionType.ToLower() == "poundstokilograms")
        {
            ViewData["ConversionType"] = "Pounds to Kilograms";
            //next 2 lines below takes inputConversion and turns it from pounds to kilograms
            UnitOf.Mass unit = new UnitOf.Mass().FromPounds(inputConversion);
            newInput = unit.ToKilograms();

            InputType = "pounds";
            OutputType = "kilograms";
        }
        else if (conversionType.ToLower() == "kilogramstopounds")
        {
            ViewData["ConversionType"] = "Kilograms to Pounds";
            //next 2 lines below takes inputConversion and turns it from kilograms to pounds
            UnitOf.Mass unit = new UnitOf.Mass().FromKilograms(inputConversion);
            newInput = unit.ToPounds();

            InputType = "kilograms";
            OutputType = "pounds";
        }
        else if (conversionType.ToLower() == "bitstobytes")
        {
            ViewData["ConversionType"] = "Bits To Bytes";
            //next 2 lines below takes inputConversion and turns it from bytes to gigabytes
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBits(inputConversion);
            newInput = unit.ToBytes();

            InputType = "bits";
            OutputType = "bytes";
        }
        else if (conversionType.ToLower() == "bytestobits")
        {
            ViewData["ConversionType"] = "Bytes To Bits";
            //next 2 lines below takes inputConversion and turns it from gigabytes to bytes
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBytes(inputConversion);
            newInput = unit.ToBits();

            InputType = "bytes";
            OutputType = "bits";
        }
        else if (conversionType.ToLower() == "minutestohours")
        {
            ViewData["ConversionType"] = "Minutes To Hours";
            //next 2 lines below takes inputConversion and turns it from minutes to hours
            UnitOf.Time unit = new UnitOf.Time().FromMinutes(inputConversion);
            newInput = unit.ToHours();

            InputType = "minutes";
            OutputType = "hours";
        }
        else if (conversionType.ToLower() == "hourstominutes")
        {
            ViewData["ConversionType"] = "Hours To Minutes";
            //next 2 lines below takes inputConversion and turns it from hours to minutes
            UnitOf.Time unit = new UnitOf.Time().FromHours(inputConversion);
            newInput = unit.ToMinutes();

            InputType = "hours";
            OutputType = "minutes";
        }
        else
        {
            //This is designed to catch errors in the conversionType part.
            ViewData["ErrorMessage"] = "Unknown or unsupported conversion type. Try again.";
            ViewData["ConversionType"] = "";
            Input = "0";

            InputType = "";
            OutputType = "";
        }

        //line below tales newInput and rounds it.
        newInput = Math.Round(newInput, 4);
        //line below takes newInput and gives it to Output as a string
        Output = newInput.ToString();

        if (error)
        {
            //If the try/catch for the input has an issue. This uses ErrorMessage and explains why.
            ViewData["ErrorMessage"] = "Invalid input! Must be a valid number. Try Again.";
            ViewData["ConversionType"] = "";
        }
    }

}
