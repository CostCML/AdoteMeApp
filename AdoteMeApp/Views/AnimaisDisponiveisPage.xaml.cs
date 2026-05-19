using AdoteMeApp.Models;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class AnimaisDisponiveisPage : ContentPage
{
    private readonly DatabaseService _database;

    public AnimaisDisponiveisPage()
    {
        InitializeComponent();

        _database =
            MauiProgram.Current.Services
            .GetRequiredService<DatabaseService>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        List<Animal> lista =
            await _database.ListarAnimais();

        if (lista.Count == 0)
        {
            lista = new List<Animal>()
            {
                new Animal
                {
                    Nome = "Thor",
                    Especie = "Cachorro",
                    Raca = "Vira-lata",
                    Idade = "2 anos",
                    Sexo = "Macho",
                    Porte = "Médio",
                    Descricao = "Muito dócil e brincalhão.",
                    StatusAdocao = "Disponível"
                },

                new Animal
                {
                    Nome = "Mia",
                    Especie = "Gato",
                    Raca = "Siamês",
                    Idade = "1 ano",
                    Sexo = "Fêmea",
                    Porte = "Pequeno",
                    Descricao = "Calma e carinhosa.",
                    StatusAdocao = "Disponível"
                }
            };

            foreach (var animal in lista)
            {
                await _database.SalvarAnimal(
                    animal);
            }
        }

        AnimaisCollection.ItemsSource =
            await _database.ListarAnimais();
    }

    private async void OnSolicitarClicked(
        object sender,
        EventArgs e)
        {
            Button botao =
                (Button)sender;

            Animal animal =
                (Animal)botao.CommandParameter;

            await Navigation.PushAsync(
                new SolicitarAdocaoPage(
                    animal));
    }
}