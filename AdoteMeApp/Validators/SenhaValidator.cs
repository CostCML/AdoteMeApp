using System.Text.RegularExpressions;

namespace AdoteMeApp.Validators;

public static class SenhaValidator
{
    public static bool Validar(string senha)
    {
        return Regex.IsMatch(
            senha,
            @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$");
    }
}