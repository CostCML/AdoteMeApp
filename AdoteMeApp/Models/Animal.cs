namespace AdoteMeApp.Models;

public class Animal
{
    public int Id
    {
        get;
        set;
    }

    // BÁSICO

    public string Nome
    {
        get;
        set;
    } = string.Empty;

    public string Especie
    {
        get;
        set;
    } = string.Empty;

    public string Raca
    {
        get;
        set;
    } = string.Empty;

    public string Sexo
    {
        get;
        set;
    } = string.Empty;

    public string Idade
    {
        get;
        set;
    } = string.Empty;

    public string Porte
    {
        get;
        set;
    } = string.Empty;

    // DESCRIÇÃO

    public string Descricao
    {
        get;
        set;
    } = string.Empty;

    // SAÚDE

    public bool Vacinado
    {
        get;
        set;
    }

    public bool Castrado
    {
        get;
        set;
    }

    // ADOÇÃO

    public string StatusAdocao
    {
        get;
        set;
    } = "Disponível";

    // ONG

    public string NomeONG
    {
        get;
        set;
    } = string.Empty;

    // FOTO

    public string Foto
    {
        get;
        set;
    } = string.Empty;

    public string FotoPath
    {
        get;
        set;
    } = string.Empty;

    // FAVORITOS

    public bool Favorito
    {
        get;
        set;
    }
}