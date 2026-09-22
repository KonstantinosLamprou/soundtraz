using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IngestService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("TimescaleDb");

        // DbContext mit PostgreSQL konfigurieren
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Repositories registrieren
        //services.AddRepositories();

        return services;
    }

    //private static IServiceCollection AddRepositories(this IServiceCollection services)
    //{

    //    return services;
    //}
}