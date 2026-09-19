using GymManagement.Domain.Subscriptions;
using MediatR;
using ErrorOr;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscriptions;

public record GetSubscriptionsQuery() : IRequest<ErrorOr<List<Subscription>>>;