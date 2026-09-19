using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagementDbContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    
    public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : base(options)
    {
    }
}