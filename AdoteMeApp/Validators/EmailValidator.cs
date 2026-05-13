using System.Text.RegularExpressions;

namespace AdoteMeApp.Validators;

public static class EmailValidator
{
    public static bool Validar(string email)
    {
        return Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}