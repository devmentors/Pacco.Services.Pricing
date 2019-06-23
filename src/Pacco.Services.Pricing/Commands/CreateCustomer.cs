using System;
using Convey.CQRS.Commands;

namespace Pacco.Services.Pricing.Commands
{
    public class CreateCustomer : ICommand
    {
        public Guid Id { get; }
        
        public CreateCustomer(Guid id)
            => Id = id;
    }
}