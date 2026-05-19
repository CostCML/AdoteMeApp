using AdoteMeApp.Models;
using AdoteMeApp.Services;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AdoteMeApp.Views;

public partial class MapaONGsPage : ContentPage
{
    private readonly DatabaseService _database;

    private readonly GeolocationService _geo;

    public MapaONGsPage()
    {
        InitializeComponent();

        _database =
            MauiProgram.Current.Services
            .GetRequiredService<DatabaseService>();

        _geo =
            MauiProgram.Current.Services
            .GetRequiredService<GeolocationService>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

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

        Mapa.MoveToRegion(
            MapSpan.FromCenterAndRadius(
                new Location(
                    usuario.Latitude,
                    usuario.Longitude),
                Distance.FromKilometers(10)));

        List<ONG> lista =
            await _database.ListarONGs();

        foreach (var ong in lista)
        {
            Pin pin = new()
            {
                Label = ong.NomeONG,

                Address = ong.Endereco,

                Type = PinType.Place,

                Location = new Location(
                    ong.Latitude,
                    ong.Longitude)
            };

            Mapa.Pins.Add(pin);
        }
    }
}