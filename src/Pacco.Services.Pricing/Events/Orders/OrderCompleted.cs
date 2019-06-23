using System;
using Convey.CQRS.Events;
using Newtonsoft.Json;

namespace Pacco.Services.Pricing.Events.Orders
{
    public class OrderCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public OrderCompleted(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}