using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UnitConverter;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = "MilesToKilometers";

    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = "3.1415";
    public string Output { get; set; } = string.Empty;

    public string InputType = string.Empty;

    public string OutputType = string.Empty;


    public void OnGet()
    {
        ViewData["Title"] = "Conversions";

        Boolean conversionError = false;
        // ViewData["ErrorMessage"] = null;

        string input = Input;
        string conversionType = ConversionType;

        double inputConversion = 0;

        //Checks for input error. Catches it if it happens to stop it from crashing.
        try
        {
            inputConversion = Convert.ToDouble(input);
        }
        catch (Exception e)
        {
            Input = "0";
            Console.WriteLine("Invalid input: must be a number. " + e.Message);
            ViewData["ErrorMessage"] = "Invalid input value. Try again.";
            return;
        }


        //line below will represent the new, converted input
        double newInput = 0;

        /*Takes a conversion type and input given. Converts input based on conversion type.
         If the conversion type is invalid or unsupported, a warning will show.*/
        if (conversionType.ToLower() == "milestokilometers")
        {
            ViewData["ConversionType"] = "Miles to Kilometers";
            //next 2 lines below takes inputConversion and turns it from miles to kilometers
            UnitOf.Length unit = new UnitOf.Length().FromMiles(inputConversion);
            newInput = unit.ToKilometers();

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

            InputType = "miles";
            OutputType = "Kilometers";
        }
        else if(conversionType.ToLower() == "kilometerstomiles")
        {
            ViewData["ConversionType"] = "Kilometers to Miles";
            //next 2 lines below takes inputConversion and turns it from kilometers to miles
            UnitOf.Length unit = new UnitOf.Length().FromKilometers(inputConversion);
            newInput = unit.ToMiles();

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

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

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

            InputType = "pounds";
            OutputType = "kilograms";
        }
        else if (conversionType.ToLower() == "kilogramstopounds")
        {
            ViewData["ConversionType"] = "Kilograms to Pounds";
            //next 2 lines below takes inputConversion and turns it from kilograms to pounds
            UnitOf.Mass unit = new UnitOf.Mass().FromKilograms(inputConversion);
            newInput = unit.ToPounds();

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

            InputType = "kilograms";
            OutputType = "pounds";
        }
        else if (conversionType.ToLower() == "bitstobytes")
        {
            ViewData["ConversionType"] = "Bits to Bytes";
            //next 2 lines below takes inputConversion and turns it from bytes to gigabytes
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBits(inputConversion);
            newInput = unit.ToBytes();

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

            InputType = "bits";
            OutputType = "bytes";
        }
        else if (conversionType.ToLower() == "bytestobits")
        {
            ViewData["ConversionType"] = "Bytes to Bits";
            //next 2 lines below takes inputConversion and turns it from gigabytes to bytes
            UnitOf.DataStorage unit = new UnitOf.DataStorage().FromBytes(inputConversion);
            newInput = unit.ToBits();

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

            InputType = "bytes";
            OutputType = "bits";
        }
        else if (conversionType.ToLower() == "minutestohours")
        {
            ViewData["ConversionType"] = "Minutes to Hours";
            //next 2 lines below takes inputConversion and turns it from minutes to hours
            UnitOf.Time unit = new UnitOf.Time().FromMinutes(inputConversion);
            newInput = unit.ToHours();

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

            InputType = "minutes";
            OutputType = "hours";
        }
        else if (conversionType.ToLower() == "hourstominutes")
        {
            ViewData["ConversionType"] = "Hours to Minutes";
            //next 2 lines below takes inputConversion and turns it from hours to minutes
            UnitOf.Time unit = new UnitOf.Time().FromHours(inputConversion);
            newInput = unit.ToMinutes();

            /*It doesn't make sense for negative values here. This if takes values and
             ensures input and output will be positive. A negative number multiplied by
             -1 will become positive and stay the same number.*/
            if (newInput < 0)
            {
                newInput *= -1;
                double positiveInput = Convert.ToDouble(Input);
                positiveInput *= -1;
                Input = positiveInput.ToString();
            }

            InputType = "hours";
            OutputType = "minutes";
        }
        else
        {
            /* This is designed to catch errors in the conversionType part.
             View Data for Conversion Type is set to blank. */
            ViewData["ErrorMessage"] = "Unknown or unsupported conversion type. Try again.";
            ViewData["ConversionType"] = "";
            Input = "0";
            Output = "0";

            InputType = "";
            OutputType = "";
            conversionError = true;
        }

        //line below takes newInput and rounds it.
        newInput = Math.Round(newInput, 4);
        //line below takes newInput and gives it to Output as a string
        Output = newInput.ToString();

    }

}
