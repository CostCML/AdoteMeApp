using AdoteMeApp.Models;

namespace AdoteMeApp.Views;

public partial class AnimaisDisponiveisPage : ContentPage
{
    public AnimaisDisponiveisPage()
    {
        InitializeComponent();

        List<Animal> lista = new()
        {
            new Animal
            {
                Nome = "Thor",
                Sexo = "Macho",
                Idade = "2 anos",
                Porte = "Médio",
                NomeONG = "ONG Patinhas Felizes",
                Foto = "dog1.jpg"
            },

            new Animal
            {
                Nome = "Mel",
                Sexo = "Fêmea",
                Idade = "1 ano",
                Porte = "Pequeno",
                NomeONG = "ONG Amor Animal",
                Foto = "dog2.jpg"
            },

            new Animal
            {
                Nome = "Mingau",
                Sexo = "Macho",
                Idade = "3 anos",
                Porte = "Pequeno",
                NomeONG = "ONG Patinhas Felizes",
                Foto = "cat1.jpg"
            }
        };

        AnimaisCollection.ItemsSource =
            lista;
    }
}