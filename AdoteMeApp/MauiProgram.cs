using AdoteMeApp.Services;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace AdoteMeApp;

public static class MauiProgram
{
    public static MauiApp Current
    {
        get;
        private set;
    }

    public static MauiApp CreateMauiApp()
    {
        var builder =
            MauiApp.CreateBuilder();

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

        // SERVICES

        builder.Services.AddSingleton<
            DatabaseService>();

        builder.Services.AddSingleton<
            AuthService>();

        builder.Services.AddSingleton<
            CryptographyService>();

        builder.Services.AddSingleton<
            ValidationService>();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

        builder.Services.AddSingleton<
            GeolocationService>();

        Current = builder.Build();

        return Current;
    }
}