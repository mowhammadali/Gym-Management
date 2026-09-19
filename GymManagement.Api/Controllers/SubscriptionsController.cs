using ErrorOr;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : Controller
{
    private readonly IMediator _mediator;

    public SubscriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionRequest request)
    {
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString());

        var createSubscriptionResult = await _mediator.Send(command);

        return createSubscriptionResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
            error => Problem()
        );
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscriptionById([FromRoute] Guid subscriptionId)
    {
        var query = new GetSubscriptionQuery(subscriptionId);

        var result = await _mediator.Send(query);

        return result.MatchFirst(
            subscription =>
                Ok(new SubscriptionResponse(subscription.Id,
                    Enum.Parse<SubscriptionType>(subscription.SubscriptionType))),
            error => Problem()
        );
    }
}