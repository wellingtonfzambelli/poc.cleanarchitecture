using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Infrastructure.Shared.Helpers;

public static class StringHelpers
{
    public static string TruncateString(this string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input) || input.Length <= maxLength)
            return input;

        return input.Substring(0, maxLength);
    }

    public static string RemoverAcentuacao(this string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return texto;


        var normalized = texto.Normalize(NormalizationForm.FormD);

        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        // Retorna sem acentos e normalizado
        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    public static bool EmailValidation(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var regex = new Regex(@"^(?!.*\.\.)([A-Za-z0-9._%+-]+)@([A-Za-z0-9.-]+\.[A-Za-z]{2,})$",
                              RegexOptions.Compiled | RegexOptions.IgnoreCase);

        return regex.IsMatch(email);
    }    
}