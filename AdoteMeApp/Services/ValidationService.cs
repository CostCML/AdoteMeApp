using System.Text.RegularExpressions;

namespace AdoteMeApp.Services;

public class ValidationService
{
    public bool EmailValido(string email)
    {
        return Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public bool SenhaForte(string senha)
    {
        return Regex.IsMatch(
            senha,
            @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$");
    }

    public bool CNPJValido(string cnpj)
    {
        cnpj =
            Regex.Replace(cnpj, @"\D", "");

        return cnpj.Length == 14;
    }

    public bool CPFValido(string cpf)
    {
        cpf =
            Regex.Replace(cpf, @"\D", "");

        return cpf.Length == 11;
    }
}