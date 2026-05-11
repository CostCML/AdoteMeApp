using AdoteMeApp.Models;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class BuscarONGsPage : ContentPage
{
    private readonly GeolocationService _geoService;

    public BuscarONGsPage()
    {
        InitializeComponent();

        _geoService = new GeolocationService();
    }

    private async void OnBuscarClicked(
        object sender,
        EventArgs e)
    {
        var localizacao =
            await _geoService.ObterLocalizacao();

        if (localizacao == null)
        {
            await DisplayAlert(
                "Erro",
                "Não foi possível obter a localização.",
                "OK");

            return;
        }

        double latitudeUsuario = localizacao.Latitude;
        double longitudeUsuario = localizacao.Longitude;

        List<ONG> lista = ObterONGs();

        var ongsProximas =
            lista.Where(ong =>
            {
                double distancia =
                    Location.CalculateDistance(
                        latitudeUsuario,
                        longitudeUsuario,
                        ong.Latitude,
                        ong.Longitude,
                        DistanceUnits.Kilometers);

                return distancia <= 50;
            })
            .ToList();

        OngsCollection.ItemsSource = ongsProximas;

        await DisplayAlert(
            "GPS",
            $"{ongsProximas.Count} ONGs encontradas próximas.",
            "OK");
    }

    private List<ONG> ObterONGs()
    {
        return new List<ONG>
        {
            new ONG
            {
                NomeONG = "Patinhas Felizes",
                NomeResponsavel = "Maria Silva",
                Endereco = "São José do Rio Preto",
                Telefone = "(17) 99999-9999",
                Latitude = -20.8113,
                Longitude = -49.3758
            },

            new ONG
            {
                NomeONG = "Amor Animal",
                NomeResponsavel = "João Souza",
                Endereco = "Mirassol",
                Telefone = "(17) 98888-8888",
                Latitude = -20.8187,
                Longitude = -49.5206
            }
        };
    }
}