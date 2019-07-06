using System;
using Convey.CQRS.Events;

namespace Pacco.Services.Pricing.Api.Events.Customers
{
    public class CustomerCreated : IEvent
    {
        public Guid Id { get; }

        public CustomerCreated(Guid id)
        {
            Id = id;
        }
    }
}