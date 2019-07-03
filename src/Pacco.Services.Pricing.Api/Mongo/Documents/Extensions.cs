using Pacco.Services.Pricing.Api.Core.Entities;

namespace Pacco.Services.Pricing.Api.Mongo.Documents
{
    public static class Extensions
    {
        public static Customer AsEntity(this CustomerDocument document)
            => document is null? null : new Customer(document.Id, document.IsVip, document.CompletedOrdersNumber);

        public static CustomerDocument AsDocument(this Customer entity)
            => new CustomerDocument
            {
                Id = entity.Id,
                IsVip = entity.IsVip,
                CompletedOrdersNumber = entity.CompletedOrdersNumber
            };
    }
}