namespace HomeApi.Domain.Exceptions;

public class UnsupportedCurrencyException : Exception
{
    public UnsupportedCurrencyException(string code)
        : base($"Colour \"{code}\" is unsupported.")
    {
    }
}
