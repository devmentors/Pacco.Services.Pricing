using System;

namespace Pacco.Services.Pricing.Core.Exceptions
{
    public class CustomerNotFoundException : ExceptionBase
    {
        public override string Code => "client_not_found";
        
        public CustomerNotFoundException(Guid id)
            : base($"Client not found: {id}.")
        {
        }
    }
}