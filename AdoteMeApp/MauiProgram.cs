using AdoteMeApp.Services;
using Microsoft.Extensions.Logging;

namespace AdoteMeApp;

public static class MauiProgram
{
    public static MauiApp Current { get; private set; } = null!;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont(
                    "OpenSans-Regular.ttf",
                    "OpenSansRegular");

                fonts.AddFont(
                    "OpenSans-Semibold.ttf",
                    "OpenSansSemibold");
            });

        builder.Services.AddSingleton<DatabaseService>();

        builder.Services.AddSingleton<AuthService>();

        builder.Services.AddSingleton<ValidationService>();

        builder.Services.AddSingleton<GeolocationService>();

        builder.Services.AddSingleton<CryptographyService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        Current = builder.Build();

        return Current;
    }
}