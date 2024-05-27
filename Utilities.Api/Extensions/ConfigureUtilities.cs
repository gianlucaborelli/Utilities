using Api.Utilities.Data.Context;
using Api.Utilities.Data.Implementations;
using Api.Utilities.Domain.Repository;
using Api.Utilities.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Utilities.Extensions
{
    public static class ConfigureUtilities
    {
        public static void AddUtilities(this IServiceCollection serviceCollection)
        {   
            serviceCollection.AddDbContext<AppDbContext>(
            options => options.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"))
            );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IEmailProviderRepository, EmailProviderImplementation>();

            serviceCollection.AddTransient<IEmailProviderService, EmailProviderService>();
        }
    }
}