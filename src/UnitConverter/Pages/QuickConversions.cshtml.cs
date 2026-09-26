using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    //public ConversionsModel ConversionQuick { get; set; } = new ConversionsModel();
    // public void OnGet()
    // {
    //
    // }
    // [BindProperty(SupportsGet = true)]
    // public string input {get;set;}
   // [BindProperty(SupportsGet = true)]
   // public string conversionTypes {get;set;}

    public IActionResult OnGetMilesToKilometers(string input)
    {
        // input = Conversion.Input;
        // Conversion.ConversionType = ConversionTypes.MilesToKilometers;
        return RedirectToPage("/Conversions");
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {

        return RedirectToPage(ConversionTypes.MilesToKilometers, input);

    }





}
