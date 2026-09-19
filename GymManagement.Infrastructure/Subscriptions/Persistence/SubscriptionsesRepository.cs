using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsesRepository : ISubscriptionsRepository
{
    private readonly GymManagementDbContext _context;

    public SubscriptionsesRepository(GymManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        await _context.Subscriptions.AddAsync(subscription);

        await _context.SaveChangesAsync();
    }

    public async Task<Subscription?> GetSubscriptionAsync(Guid subscriptionId)
    {
        return await _context.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriptionId);
    }
}