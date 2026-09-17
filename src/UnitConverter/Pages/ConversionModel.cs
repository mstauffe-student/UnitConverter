using Microsoft.AspNetCore.Mvc;

namespace UnitConverter.Pages;

public class ConversionModel
{
    public string ConversionType {get; set;} = String.Empty;

    public string Input  {get; set;} = String.Empty;
    public string Output  {get; set;} = String.Empty;

    public static class ConversionTypes;

}
