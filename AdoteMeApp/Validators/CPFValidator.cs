using System.Text.RegularExpressions;

namespace AdoteMeApp.Validators;

public static class CPFValidator
{
    public static bool Validar(string cpf)
    {
        cpf = Regex.Replace(cpf, @"\D", "");

        return cpf.Length == 11;
    }
}