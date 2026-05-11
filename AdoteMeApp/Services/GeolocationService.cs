namespace AdoteMeApp.Services;

public class GeolocationService
{
    public async Task<Location?> ObterLocalizacao()
    {
        try
        {
            GeolocationRequest request =
                new GeolocationRequest(
                    GeolocationAccuracy.High,
                    TimeSpan.FromSeconds(10));

            return await Geolocation.Default.GetLocationAsync(request);
        }
        catch
        {
            return null;
        }
    }
}