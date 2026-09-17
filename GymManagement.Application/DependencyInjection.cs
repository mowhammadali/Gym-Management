using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(option => { option.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)); });

        return services;
    }
}