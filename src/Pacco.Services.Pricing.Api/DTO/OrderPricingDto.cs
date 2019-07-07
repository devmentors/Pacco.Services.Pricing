namespace Pacco.Services.Pricing.DTO
{
    public class OrderPricingDto
    {
        public decimal OrderPrice { get; set; }
        public decimal CustomerDiscount { get; set; }
        public decimal OrderDiscountPrice => OrderPrice - (CustomerDiscount * OrderPrice) > 0
            ? OrderPrice - (CustomerDiscount * OrderPrice)
            : 1;
    }
}