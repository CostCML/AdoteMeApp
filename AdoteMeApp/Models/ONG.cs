namespace AdoteMeApp.Models;

public class ONG
{
    public int Id { get; set; }

    public string NomeONG { get; set; } = string.Empty;

    public string NomeResponsavel { get; set; } = string.Empty;

    public string Endereco { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}