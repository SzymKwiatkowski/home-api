using Ardalis.GuardClauses;

namespace HomeApi.Domain.Extensions;

public static class GuardExtensions
{
    public static void Null(params object[] parameters)
    {
        foreach (var parameter in parameters)
        {
            Guard.Against.Null(parameter, parameter.GetType().Name);
        }
    }
}
