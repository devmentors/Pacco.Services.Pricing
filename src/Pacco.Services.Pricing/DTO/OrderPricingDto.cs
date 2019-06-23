using System;

namespace Pacco.Services.Pricing.DTO
{
    public class OrderPricingDto
    {
        public Guid OrderId { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal ClientDiscount { get; set; }
        public decimal OrderDiscountPrice => OrderPrice - ClientDiscount;
    }
}