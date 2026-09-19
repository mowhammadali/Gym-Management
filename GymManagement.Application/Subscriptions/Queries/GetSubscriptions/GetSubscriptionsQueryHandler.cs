using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscriptions;

public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, ErrorOr<List<Subscription>>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public GetSubscriptionsQueryHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<List<Subscription>>> Handle(GetSubscriptionsQuery request,
        CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionsRepository.GetSubscriptionsAsync();

        return subscriptions.ToList();
    }
}