using System;
using Convey.CQRS.Commands;

namespace Pacco.Services.Pricing.Api.Commands
{
    public class AddCustomerCompletedOrder : ICommand
    {
        public Guid CustomerId { get; }

        public AddCustomerCompletedOrder(Guid customerId)
            => CustomerId = customerId;
    }
}