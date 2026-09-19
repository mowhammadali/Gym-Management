using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Common.Persistence;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;

namespace GymManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<GymManagementDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("GymManagementConnectionString")));
        services.AddScoped<ISubscriptionsRepository, SubscriptionsesRepository>();

        return services;
    }
}