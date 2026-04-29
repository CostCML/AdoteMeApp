namespace AdoteMeApp.Models;

public class Animal
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Especie { get; set; } = string.Empty;

    public string Idade { get; set; } = string.Empty;

    public string StatusResgate { get; set; } = string.Empty;

    public string LocalAbrigo { get; set; } = string.Empty;

    public string Observacoes { get; set; } = string.Empty;

    public string StatusAdocao { get; set; } = string.Empty;
}