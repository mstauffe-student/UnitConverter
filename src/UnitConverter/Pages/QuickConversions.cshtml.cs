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
    public string OutputType = string.Empty;


    /*
     * Default OnGet
     */
   public void OnGet()
   {

   }

   /**
    * Takes a string input and tries turing it into a decimal. It then
    * will take the decimal and insert it into the Convert method from the
    * UnitOfConversionService. Also, takes a string for the conversion type and
    * inserts it into the Convert method and OutputType method. Allows for an output
    * and a ype of output to be shown on the html page. Returns the page.
    */
   public IActionResult PerformAction(string input, string conversion)
   {
       decimal newInput = 0;
       try
       {
           newInput = Convert.ToDecimal(input);
       }
       catch (Exception e)
       {
           Console.WriteLine("Invalid input: must be a number. " + e.Message);
           ViewData["ErrorMessage"] = "Error! Invalid input value. Try again.";
           return Page();
       }

       Output = _conversionService.Convert(newInput, conversion);
       OutputType = _conversionService.OutputType(conversion);
       return Page();
   }
   /*
    * Takes input from MilesToKilometers handler and takes it to Conversions.
    * @return uses PerformConversion() with MilesToKilometers and selected input.
    */
    public IActionResult OnGetMilesToKilometers(string input)
    {
        return PerformAction(input, ConversionTypes.MilesToKilometers);
    }

    /*
     * Takes input from KilometersToMiles handler and takes it to Conversions.
     * @return uses PerformConversion() with KilometersToMiles and selected input.
     */
    public IActionResult OnGetKilometersToMiles(string input)
    {
        return PerformAction(input, ConversionTypes.KilometersToMiles);
    }

    /*
     * Takes input from FahrenheitToCelsius handler and takes it to Conversions.
     * @return uses PerformConversion() with FahrenheitToCelsius and selected input.
     */
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return PerformAction(input, ConversionTypes.FahrenheitToCelsius);
    }

    /*
     * Takes input from CelsiusToFahrenheit handler and takes it to Conversions.
     * @return uses PerformConversion() with CelsiusToFahrenheit and selected input from the range.
     */
    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return PerformAction(input, ConversionTypes.CelsiusToFahrenheit);
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
     * @return uses PerformConversion() with PoundsToKilograms and selected input from the list.
     */
    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return PerformAction(input, ConversionTypes.PoundsToKilograms);
    }

    /*
     * Takes input from KilogramsToPounds handler and takes it to Conversions.
     * @return uses PerformConversion() with KilogramsToPounds and selected input.
     */
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return PerformAction(input, ConversionTypes.KilogramsToPounds);
    }

    /*
     * Takes input from BitsToBytes handler and takes it to Conversions.
     * @return uses PerformConversion() with BitsToBytes and selected input.
     */
    public IActionResult OnGetBitsToBytes(string input)
    {
        return PerformAction(input, ConversionTypes.BitsToBytes);
    }

    /*
     * Takes input from BytesToBits handler and takes it to Conversions.
     * @return uses PerformConversion() with BytesToBits and selected input.
     */
    public IActionResult OnGetBytesToBits(string input)
    {
        return PerformAction(input, ConversionTypes.BytesToBits);
    }

    /*
     * Takes input from MinutesToHours handler and takes it to Conversions.
     * @return uses PerformConversion() with MinutesToHours and selected input from the range.
     */
    public IActionResult OnGetMinutesToHours(string input)
    {
        return PerformAction(input, ConversionTypes.MinutesToHours);
    }

    /*
     * Takes input from HoursToMinutes handler and takes it to Conversions.
     * @return uses PerformConversion() with HoursToMinutes and selected input from the range.
     */
    public IActionResult OnGetHoursToMinutes(string input)
    {
        return PerformAction(input, ConversionTypes.HoursToMinutes);
    }

}
