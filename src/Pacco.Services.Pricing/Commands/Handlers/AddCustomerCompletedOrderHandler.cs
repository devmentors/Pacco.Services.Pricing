using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Pacco.Services.Pricing.Core.Repositories;

namespace Pacco.Services.Pricing.Commands.Handlers
{
    public class AddCustomerCompletedOrderHandler : ICommandHandler<AddCustomerCompletedOrder>
    {
        private readonly ICustomersRepository _repository;

        public AddCustomerCompletedOrderHandler(ICustomersRepository repository)
            => _repository = repository;

        public async Task HandleAsync(AddCustomerCompletedOrder command)
        {
            var customer = await _repository.GetAsync(command.CustomerId);
            customer.AddCompletedOrder();

            await _repository.UpdateAsync(customer);
        }
    }
}