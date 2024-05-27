using Api.IsTempMail.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Api.IsTempMail.Extensions
{
    public static class ConfigureDomainsValidator
    {
        public static void AddIsTempMailService(this IServiceCollection serviceCollection)
        {            
            serviceCollection.AddTransient<IIsTempMailService, IsTempMailService>();
        }
    }
}