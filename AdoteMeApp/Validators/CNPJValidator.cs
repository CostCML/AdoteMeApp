using System.Text.RegularExpressions;

namespace AdoteMeApp.Validators;

public static class CNPJValidator
{
    public static bool Validar(string cnpj)
    {
        cnpj = Regex.Replace(cnpj, @"\D", "");

        return cnpj.Length == 14;
    }
}