using System;

namespace Pacco.Services.Pricing.DTO
{
    public class OrderPricingDto
    {
        public Guid OrderId { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal CustomerDiscount { get; set; }
        public decimal OrderDiscountPrice => OrderPrice - CustomerDiscount;
    }
}