using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Pacco.Services.Pricing.Core.Repositories;

namespace Pacco.Services.Pricing.Commands.Handlers
{
    public class MakeCustomerVipHandler : ICommandHandler<MakeCustomerVip>
    {
        private readonly ICustomersRepository _repository;

        public MakeCustomerVipHandler(ICustomersRepository repository)
            => _repository = repository;
        
        public async Task HandleAsync(MakeCustomerVip command)
        {
            var customer = await _repository.GetAsync(command.Id);
            customer.MakeVip();

            await _repository.UpdateAsync(customer);
        }
    }
}