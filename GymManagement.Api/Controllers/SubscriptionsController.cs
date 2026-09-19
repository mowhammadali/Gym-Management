using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscriptions;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.SubscriptionType;

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
        if (DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType))
        {
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Subscription type is invalid");
        }

        var command = new CreateSubscriptionCommand(subscriptionType, request.AdminId);

        var createSubscriptionResult = await _mediator.Send(command);

        return createSubscriptionResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id,
                Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))),
            error => Problem()
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetSubscriptions()
    {
        var query = new GetSubscriptionsQuery();

        var result = await _mediator.Send(query);

        return result.MatchFirst(
            subscriptions => Ok(subscriptions.Select(s =>
                new SubscriptionResponse(s.Id, Enum.Parse<SubscriptionType>(s.SubscriptionType.Name)))),
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
                    Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))),
            error => Problem()
        );
    }
}