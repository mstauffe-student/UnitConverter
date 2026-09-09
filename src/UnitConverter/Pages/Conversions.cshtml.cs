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


    public void OnGet(string input, string conversionType)
    {
        Input = input;
        double inputConversion = 0;
        ViewData["ConversionType"] = "Test.";
        try
        {
            inputConversion = Convert.ToDouble(Input);
        }
        catch (Exception e)
        {
            Input = "Invalid input! Must be a positive number. Try again.";
            Console.WriteLine("Invalid input: must be a number. " + e.Message);
        }

        try
        {
            ConversionType = conversionType;
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid conversion type: " + e.Message);
            throw;
        }



        ViewData["Title"] = "Conversions";

        //line below tranforms Input into a double

        double newInput = 0;

        if (conversionType == "MilesToKilometers")
        {
            ViewData["ConversionType"] = "Miles to Kilometers";
            //next 2 lines below takes inputConversion and turns it from miles to kilometers
            UnitOf.Length unit = new UnitOf.Length().FromMiles(inputConversion);
            newInput = unit.ToKilometers();
        }



        //line below tales newInput (Now in kilometers) and rounds it.
        newInput = Math.Round(newInput, 4);
        //line below takes newInput and gives it to Output as a string
        Output = newInput.ToString();

    }

}
