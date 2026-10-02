namespace UnitConverter;

public interface IConversionService
{
    decimal Convert(decimal value, string conversionType);
    string OutputType(string conversionType);

}
