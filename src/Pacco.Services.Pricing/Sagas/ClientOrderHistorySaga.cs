using System;
using Chronicle;

namespace Pacco.Services.Pricing.Sagas
{
    public class ClientOrderHistory
    {
        public Guid CustomerId { get; set; }
        public int CompletedOrdersNumber { get; set; }
    }
    
    public class ClientOrderHistorySaga : Saga<ClientOrderHistory>
    {
        
    }
}