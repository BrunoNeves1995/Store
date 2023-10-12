using Store.Domain.Entities.Contracts;
using Store.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        protected Discount() { }

        public Discount(decimal amount, DateTime expireDate)
        {
            Amount = amount;
            ExpireDate = expireDate;

            AddNotifications(new CreateDiscountContrac(this));
        }

        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set; }


        public bool IsValide()
        {
            return DateTime.Compare(DateTime.UtcNow, ExpireDate) < 0;
        }

        public decimal Value()
        {
            if(this.IsValide() && Notifications.Count == 0)
                return Amount;
            else
                return 0;
        }
    }
}
