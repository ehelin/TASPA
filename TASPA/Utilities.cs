using BLL;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;

// TODO - Move to central location
namespace TASPA
{
    public class Utilities
    {
        public static IServiceCollection SetDI(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITaspaData, TaspaData>();
            serviceCollection.AddSingleton<ITaspaService, TaspaService>();

            return serviceCollection;
        }
    }
}
