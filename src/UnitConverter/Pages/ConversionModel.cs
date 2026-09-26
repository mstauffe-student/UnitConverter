using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Pages;
using UnitConverter.Models;

namespace UnitConverter.Models;

public class ConversionModel
{
    //[Display(Name = "Conversion Type")]
    public string ConversionType {get; set;} = string.Empty;

    public string Input  {get; set;} = string.Empty;
    public string Output  {get; set;} = String.Empty;



}
