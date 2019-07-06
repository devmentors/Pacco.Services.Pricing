using System;
using Convey.CQRS.Events;

namespace Pacco.Services.Pricing.Api.Events.Orders
{
    public class OrderCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        public OrderCompleted(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}