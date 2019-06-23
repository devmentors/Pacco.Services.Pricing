using System;
using Convey.Types;

namespace Pacco.Services.Pricing.Mongo.Documents
{
    public class CustomerDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public bool IsVip { get; set; }
        public int CompletedOrdersNumber { get; set; }
    }
}