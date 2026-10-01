using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;


namespace UnitConverter.Pages;



public class QuickConversions : PageModel
{


    private readonly IConversionService _conversionService;
    public QuickConversions(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    public decimal Output { get; set; } = 0;


    /*
     * Default OnGet
     */
   public void OnGet()
   {

   }

   public IActionResult PerformAction(string input, string conversion)
   {
       decimal newInput = Convert.ToDecimal(input);
       Output = _conversionService.Convert(newInput, conversion);
       return Page();
   }
   /*
    * Takes input from MilesToKilometers handler and takes it to Conversions.
    * @return redirects back to Conversion page with MilesToKilometers and selected input.
    */
    public IActionResult OnGetMilesToKilometers(string input)
    {
        return PerformAction(input, ConversionTypes.MilesToKilometers);
        //return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.MilesToKilometers, input = input });
    }

    /*
     * Takes input from KilometersToMiles handler and takes it to Conversions.
     * @return redirects back to Conversion page with KilometersToMiles and selected input.
     */
    public IActionResult OnGetKilometersToMiles(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.KilometersToMiles, input = input });
    }

    /*
     * Takes input from FahrenheitToCelsius handler and takes it to Conversions.
     * @return redirects back to Conversion page with FahrenheitToCelsius and selected input.
     */
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.FahrenheitToCelsius, input = input });
    }

    /*
     * Takes input from CelsiusToFahrenheit handler and takes it to Conversions.
     * @return redirects back to Conversion page with CelsiusToFahrenheit and selected input from the range.
     */
    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.CelsiusToFahrenheit, input = input });
    }

    /*
     * Sets up the selected list for the PoundsToKilograms handler.
     */
    public IEnumerable<SelectListItem> PoundOptions =>
    [
        new("1 pounds", "1"),
        new("5 pounds", "5"),
        new("10 pounds", "10"),
        new("25 pounds", "25"),
        new("50 pounds", "50"),
        new("100 pounds", "100")
    ];

    /*
     * Takes input from PoundsToKilograms handler and takes it to Conversions.
     * @return redirects back to Conversion page with PoundsToKilograms and selected input from the list.
     */
    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.PoundsToKilograms, input = input });
    }

    /*
     * Takes input from KilogramsToPounds handler and takes it to Conversions.
     * @return redirects back to Conversion page with KilogramsToPounds and selected input.
     */
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.KilogramsToPounds, input = input });
    }

    /*
     * Takes input from BitsToBytes handler and takes it to Conversions.
     * @return redirects back to Conversion page with BitsToBytes and selected input.
     */
    public IActionResult OnGetBitsToBytes(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.BitsToBytes, input = input });
    }

    /*
     * Takes input from BytesToBits handler and takes it to Conversions.
     * @return redirects back to Conversion page with BytesToBits and selected input.
     */
    public IActionResult OnGetBytesToBits(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.BytesToBits, input = input });
    }

    /*
     * Takes input from MinutesToHours handler and takes it to Conversions.
     * @return redirects back to Conversion page with MinutesToHours and selected input from the range.
     */
    public IActionResult OnGetMinutesToHours(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.MinutesToHours, input = input });
    }

    /*
     * Takes input from HoursToMinutes handler and takes it to Conversions.
     * @return redirects back to Conversion page with HoursToMinutes and selected input from the range.
     */
    public IActionResult OnGetHoursToMinutes(string input)
    {
        return RedirectToPage("/Conversions", new { conversionType = ConversionTypes.HoursToMinutes, input = input });
    }

}
