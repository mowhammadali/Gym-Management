using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsesRepository : ISubscriptionsRepository
{
    private static readonly List<Subscription> _subscriptions = new();

    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscriptions.Add(subscription);

        return Task.CompletedTask;
    }

    public Task<Subscription?> GetSubscriptionAsync(Guid subscriptionId)
    {
        Subscription? subscription =  _subscriptions.FirstOrDefault(s => s.Id == subscriptionId);
        
        return Task.FromResult(subscription);
    }
}