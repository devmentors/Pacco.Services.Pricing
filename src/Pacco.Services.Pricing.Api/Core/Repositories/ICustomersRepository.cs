using System;
using System.Threading.Tasks;
using Pacco.Services.Pricing.Api.Core.Entities;

namespace Pacco.Services.Pricing.Api.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}