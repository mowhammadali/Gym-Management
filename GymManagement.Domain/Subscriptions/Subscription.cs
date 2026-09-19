namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    private readonly Guid _adminId;
    public Guid Id { get; }
    public SubscriptionType SubscriptionType { get; } = null!;

    public Subscription(Guid adminId, SubscriptionType subscriptionType, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        _adminId = adminId;
        SubscriptionType = subscriptionType;
    }
}