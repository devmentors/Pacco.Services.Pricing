using System;
using Convey.CQRS.Queries;
using Pacco.Services.Pricing.DTO;

namespace Pacco.Services.Pricing.Queries
{
    public class GetOrderPricing : IQuery<OrderPricingDto>
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public decimal OrderPrice { get; set; }
    }
}