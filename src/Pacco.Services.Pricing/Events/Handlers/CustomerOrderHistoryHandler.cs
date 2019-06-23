using System.Threading.Tasks;
using Chronicle;
using Convey.CQRS.Events;
using Pacco.Services.Pricing.Events.Customers;
using Pacco.Services.Pricing.Events.Orders;

namespace Pacco.Services.Pricing.Events.Handlers
{
    public sealed class CustomerOrderHistoryHandler : IEventHandler<CustomerCreated>, IEventHandler<OrderCompleted>
    {
        private readonly ISagaCoordinator _sagaCoordinator;

        public CustomerOrderHistoryHandler(ISagaCoordinator sagaCoordinator)
            => _sagaCoordinator = sagaCoordinator;

        public Task HandleAsync(CustomerCreated @event)
            => _sagaCoordinator.ProcessAsync(@event, SagaContext.Empty);

        public Task HandleAsync(OrderCompleted @event)
            => _sagaCoordinator.ProcessAsync(@event, SagaContext.Empty);
    }
}