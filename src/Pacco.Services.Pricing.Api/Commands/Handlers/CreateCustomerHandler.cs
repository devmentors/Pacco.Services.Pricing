using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Pacco.Services.Pricing.Api.Core.Entities;
using Pacco.Services.Pricing.Api.Core.Repositories;

namespace Pacco.Services.Pricing.Api.Commands.Handlers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomersRepository _repository;

        public CreateCustomerHandler(ICustomersRepository repository)
            => _repository = repository;

        public async Task HandleAsync(CreateCustomer command)
        {
            var customer = new Customer(command.Id);
            await _repository.AddAsync(customer);
        }
    }
}