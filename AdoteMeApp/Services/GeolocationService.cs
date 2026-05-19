namespace AdoteMeApp.Services;

public class GeolocationService
{
    public async Task<Location?> ObterLocalizacao()
    {
        try
        {
            GeolocationRequest request =
                new(
                    GeolocationAccuracy.High,
                    TimeSpan.FromSeconds(10));

            return await Geolocation
                .Default
                .GetLocationAsync(request);
        }
        catch
        {
            return null;
        }
    }

    public double CalcularDistancia(
        double lat1,
        double lon1,
        double lat2,
        double lon2)
    {
        return Location.CalculateDistance(
            lat1,
            lon1,
            lat2,
            lon2,
            DistanceUnits.Kilometers);
    }
}