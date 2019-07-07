using Pacco.Services.Pricing.Core.Entities;

namespace Pacco.Services.Pricing.Core.Services
{
    public interface ICustomerDiscountsService
    {
        decimal CalculateDiscount(Customer customer);
    }
}