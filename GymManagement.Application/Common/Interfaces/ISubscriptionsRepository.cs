using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces;

public interface ISubscriptionsRepository
{
    Task AddSubscriptionAsync(Subscription subscription);
    Task<Subscription?> GetSubscriptionAsync(Guid subscriptionId);
    Task<IEnumerable<Subscription>> GetSubscriptionsAsync();
}