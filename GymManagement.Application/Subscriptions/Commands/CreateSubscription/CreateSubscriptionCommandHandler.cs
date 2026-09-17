using MediatR;
using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
    {
        _subscriptionRepository = subscriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request,
        CancellationToken cancellationToken)
    {
        Subscription subscription = new Subscription() { Id = Guid.NewGuid() };

        await _subscriptionRepository.AddSubscriptionAsync(subscription);

        await _unitOfWork.CommitChangesAsync();

        return subscription;
    }
}