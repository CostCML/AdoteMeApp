using SQLite;

namespace AdoteMeApp.Models;

public class SolicitacaoAdocao
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string NomeAnimal { get; set; } = string.Empty;

    public string NomeAdotante { get; set; } = string.Empty;

    public string EmailAdotante { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string Mensagem { get; set; } = string.Empty;

    public string Status { get; set; } = "Pendente";

    public DateTime DataSolicitacao { get; set; }
}