using System;
using Convey.CQRS.Commands;

namespace Pacco.Services.Pricing.Api.Commands
{
    public class CreateCustomer : ICommand
    {
        public Guid Id { get; }
        
        public CreateCustomer(Guid id)
            => Id = id;
    }
}