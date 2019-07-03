using System;
using System.Threading.Tasks;
using Chronicle;
using Convey.CQRS.Commands;
using Pacco.Services.Pricing.Api.Commands;
using Pacco.Services.Pricing.Api.Events.Customers;
using Pacco.Services.Pricing.Api.Events.Orders;

namespace Pacco.Services.Pricing.Api.Sagas
{
    public class CustomerOrderHistory
    {
        public Guid CustomerId { get; set; }
        public DateTime CustomerCreatedAt { get; set; }
        public int CompletedOrdersNumber { get; set; }
    }
    
    public class CustomerOrderHistorySaga 
          : Saga<CustomerOrderHistory>,
            ISagaStartAction<CustomerCreated>,
            ISagaAction<OrderCompleted>
    {
        private readonly ICommandDispatcher _dispatcher;

        private const int VipThreshold = 20;

        public CustomerOrderHistorySaga(ICommandDispatcher dispatcher)
            => _dispatcher = dispatcher;

        public override SagaId ResolveId(object message, ISagaContext context)
        {
            switch (message)
            {
                case CustomerCreated customerCreated:
                    return customerCreated.Id.ToString();
                case OrderCompleted orderCompleted: 
                    return orderCompleted.CustomerId.ToString();
            }
            return base.ResolveId(message, context);
        }

        public async Task HandleAsync(CustomerCreated message, ISagaContext context)
        {
            Data.CustomerId = message.Id;
            Data.CustomerCreatedAt = DateTime.UtcNow;
            
            await _dispatcher.SendAsync(new CreateCustomer(message.Id));
        }
        
        public async Task HandleAsync(OrderCompleted message, ISagaContext context)
        {
            Data.CompletedOrdersNumber++;

            await _dispatcher.SendAsync(new AddCustomerCompletedOrder(message.CustomerId));

            if (Data.CompletedOrdersNumber >= VipThreshold && HasAccountForAtLeastYear(Data.CustomerCreatedAt))
            {
                await _dispatcher.SendAsync(new MakeCustomerVip(message.CustomerId));
                Complete();
            }
        }

        public Task CompensateAsync(CustomerCreated message, ISagaContext context)
            => Task.CompletedTask;

        public Task CompensateAsync(OrderCompleted message, ISagaContext context)
            => Task.CompletedTask;
        
        private static bool HasAccountForAtLeastYear(DateTime customerCreatedAt)
            => (DateTime.UtcNow - customerCreatedAt).Days >= 365;
    }
}