using SQLite;

namespace AdoteMeApp.Models;

public class Usuario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;

    public DateTime DataNascimento { get; set; }

    public string Telefone { get; set; } = string.Empty;

    public string Endereco { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    public string Estado { get; set; } = string.Empty;

    public string CEP { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;

    public string TipoUsuario { get; set; } = string.Empty;
}