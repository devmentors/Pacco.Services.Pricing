using System;
using Convey.CQRS.Events;
using Newtonsoft.Json;

namespace Pacco.Services.Pricing.Events.Customers
{
    public class CustomerCreated : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public CustomerCreated(Guid id)
        {
            Id = id;
        }
    }
}