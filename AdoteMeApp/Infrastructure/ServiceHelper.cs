using Microsoft.Extensions.DependencyInjection;

namespace AdoteMeApp.Infrastructure;

public static class ServiceHelper
{
    public static IServiceProvider Services { get; set; }

    public static T GetRequiredService<T>()
    {
        return Services.GetRequiredService<T>();
    }
}