using Pacco.Services.Pricing.Core.Entities;

namespace Pacco.Services.Pricing.Core.Services
{
    public class CustomerDiscountsService : ICustomerDiscountsService
    {
        public decimal CalculateCustomerDiscount(Customer customer, decimal orderPrice)
        {
            var discount = 0.0m;

            if (customer.CompletedOrdersNumber >= 10)
            {
                discount = 0.1m;
            }
            else if (customer.CompletedOrdersNumber < 10 && customer.CompletedOrdersNumber > 3)
            {
                discount = 0.05m;
            }
            else if(customer.CompletedOrdersNumber <= 3 && customer.CompletedOrdersNumber > 0)
            {
                discount = 0.02m;
            }

            if (customer.IsVip)
            {
                discount += 0.1m;
            }

            return orderPrice * (1 - discount);
        }
    }
}