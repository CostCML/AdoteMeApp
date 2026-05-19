using SQLite;

namespace AdoteMeApp.Models;

public class Animal
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Especie { get; set; } = string.Empty;

    public string Raca { get; set; } = string.Empty;

    public string Idade { get; set; } = string.Empty;

    public string Sexo { get; set; } = string.Empty;

    public string Porte { get; set; } = string.Empty;

    public bool Vacinado { get; set; }

    public bool Castrado { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public string StatusAdocao { get; set; } = string.Empty;

    public string FotoPath { get; set; } = string.Empty;
}