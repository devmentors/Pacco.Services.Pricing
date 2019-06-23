using System;

namespace Pacco.Services.Pricing.Core.Entities
{
    public class Customer
    {
        public Guid Id { get; protected set; }
        public bool IsVip { get; protected set; }
        public int CompletedOrdersNumber { get; protected set; }

        public Customer(Guid id)
        {
            Id = id;
        }
        
        public Customer(Guid id, bool isVip, int completedOrdersNumber) : this(id)
        {
            IsVip = isVip;
            CompletedOrdersNumber = completedOrdersNumber;
        }

        public void MakeVip()
            => IsVip = true;

        public void AddCompletedOrder()
            => CompletedOrdersNumber++;
    }
}