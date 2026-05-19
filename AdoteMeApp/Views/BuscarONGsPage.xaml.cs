using AdoteMeApp.Models;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class BuscarONGsPage : ContentPage
{
    private readonly DatabaseService _database;

    private readonly GeolocationService _geo;

    public BuscarONGsPage()
    {
        InitializeComponent();

        _database =
            MauiProgram.Current.Services
            .GetRequiredService<DatabaseService>();

        _geo =
            MauiProgram.Current.Services
            .GetRequiredService<GeolocationService>();
    }

    private async void OnBuscarClicked(
        object sender,
        EventArgs e)
    {
        Location? usuario =
            await _geo.ObterLocalizacao();

        if (usuario == null)
        {
            await DisplayAlert(
                "Erro",
                "Não foi possível obter localização.",
                "OK");

            return;
        }

        List<ONG> lista =
            await _database.ListarONGs();

        if (lista.Count == 0)
        {
            lista = new()
            {
                new ONG
                {
                    NomeONG = "Patinhas Felizes",
                    Endereco = "São José do Rio Preto",
                    Telefone = "(17) 99999-9999",
                    Latitude = -20.8113,
                    Longitude = -49.3758
                },

                new ONG
                {
                    NomeONG = "Amor Animal",
                    Endereco = "Mirassol",
                    Telefone = "(17) 98888-8888",
                    Latitude = -20.8178,
                    Longitude = -49.5206
                }
            };

            foreach (var ong in lista)
            {
                await _database.SalvarONG(
                    ong);
            }
        }

        var proximas =
            lista
            .OrderBy(o =>
                _geo.CalcularDistancia(
                    usuario.Latitude,
                    usuario.Longitude,
                    o.Latitude,
                    o.Longitude))
            .ToList();

        OngsCollection.ItemsSource =
            proximas;
    }

    private async void OnMapaClicked(
        object sender,
        EventArgs e)
        {
            await Navigation.PushAsync(
                new MapaONGsPage());
        }
}