using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;

    public void OnGet()
    {
        Input = "3.1415";
        ViewData["ConversionType"] = "Miles to Kilometers";
        ViewData["Title"] = "Conversions";
        //line below tranforms Input into a double
        double inputConversion = Convert.ToDouble(Input);

        //next 2 lines below takes inputConversion and turns it from miles to kilometers
        UnitOf.Length unit = new UnitOf.Length().FromMiles(inputConversion);
        double newInput = unit.ToKilometers();
        //line below tales newInput (Now in kilometers) and rounds it.
        newInput = Math.Round(newInput, 4);
        //line below takes newInput and gives it to Output as a string
        Output = newInput.ToString();

    }

}
