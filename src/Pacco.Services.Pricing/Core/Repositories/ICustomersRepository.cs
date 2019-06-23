using System;
using System.Threading.Tasks;
using Pacco.Services.Pricing.Core.Entities;

namespace Pacco.Services.Pricing.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}