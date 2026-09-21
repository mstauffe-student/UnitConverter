using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Models;

public class ConversionModel
{
    public string ConversionType {get; set;} = string.Empty;

    public string Input  {get; set;} = string.Empty;
    public string Output  {get; set;} = String.Empty;



}
