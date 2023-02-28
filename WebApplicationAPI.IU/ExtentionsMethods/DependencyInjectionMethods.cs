using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Repositories;

namespace WebApplicationAPI.IU.ExtentionsMethods;

public static class DependencyInjectionMethods
{
    public static void AddInjection( this IServiceCollection services)
    {
        services.AddScoped<IRecipiesRepository, DefaultRecipieRepository>();
    }
}