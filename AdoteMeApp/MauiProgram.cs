using AdoteMeApp.Controllers;
using AdoteMeApp.Data;
using AdoteMeApp.Infrastructure;

namespace AdoteMeApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "adoteme.db3");

        builder.Services.AddSingleton<AppDatabase>(s => new AppDatabase(dbPath));
        builder.Services.AddSingleton<OngController>();

        var app = builder.Build();

        ServiceHelper.Services = app.Services;

        return app;
    }
}