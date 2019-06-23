using System;
using Convey.CQRS.Commands;

namespace Pacco.Services.Pricing.Commands
{
    public class MakeCustomerVip : ICommand
    {
        public Guid Id { get; }
        
        public MakeCustomerVip(Guid id)
            => Id = id;
    }
}