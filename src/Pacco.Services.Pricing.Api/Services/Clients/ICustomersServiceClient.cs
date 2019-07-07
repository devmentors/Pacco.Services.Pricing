using System;
using System.Threading.Tasks;
using Pacco.Services.Pricing.DTO;

namespace Pacco.Services.Pricing.Services.Clients
{
    public interface ICustomersServiceClient
    {
        Task<CustomerDto> GetAsync(Guid id);
    }
}