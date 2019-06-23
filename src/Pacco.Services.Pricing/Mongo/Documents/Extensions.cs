using Pacco.Services.Pricing.Core.Entities;

namespace Pacco.Services.Pricing.Mongo.Documents
{
    public static class Extensions
    {
        public static Customer AsEntity(this CustomerDocument document)
            => new Customer(document.Id, document.IsVip, document.CompletedOrdersNumber);

        public static CustomerDocument AsDocument(this Customer entity)
            => new CustomerDocument
            {
                Id = entity.Id,
                IsVip = entity.IsVip,
                CompletedOrdersNumber = entity.CompletedOrdersNumber
            };
    }
}