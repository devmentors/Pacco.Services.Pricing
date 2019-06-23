using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Pacco.Services.Pricing.Core.Entities;
using Pacco.Services.Pricing.Core.Repositories;
using Pacco.Services.Pricing.Mongo.Documents;

namespace Pacco.Services.Pricing.Mongo.Repositories
{
    public class CustomersMongoRepository : ICustomersRepository
    {
        private readonly IMongoRepository<CustomerDocument, Guid> _repository;

        public CustomersMongoRepository(IMongoRepository<CustomerDocument, Guid> repository)
            => _repository = repository;

        public async Task<Customer> GetAsync(Guid id)
        {
            var document = await _repository.GetAsync(id);
            return document.AsEntity();
        }

        public async Task AddAsync(Customer customer)
        {
            var document = customer.AsDocument();
            await _repository.AddAsync(document);
        }

        public async Task UpdateAsync(Customer customer)
        {
            var document = customer.AsDocument();
            await _repository.UpdateAsync(document);
        }
    }
}