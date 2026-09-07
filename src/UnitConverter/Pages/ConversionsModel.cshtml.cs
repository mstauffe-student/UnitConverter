using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter;

public class Conversion : PageModel
{
    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    public void OnGet()
    {
        Input = "3.1415";
        ViewData["ConversionType"] = "Miles to Kilometers";
        ViewData["Title"] = "Conversions";
        double inputConversion = Convert.ToDouble(Input);

        UnitOf.Length unit = new UnitOf.Length().FromMiles(inputConversion);
        double newInput = unit.ToKilometers();
        newInput = Math.Round(newInput, 4);
        Output = newInput.ToString();

    }

}
