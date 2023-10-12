using Store.Domain.Entities.Contracts;
using Store.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Product : Entity
    {
        protected Product() { }

        public Product(string title, decimal price)
        {
            Title = title;
            Price = price;
            Active = true;

            AddNotifications(new CreateProductContract(this));
        }

        public string Title { get; private set; } = null!;
        public decimal Price { get; private set; }
        public bool Active { get; private set; }

        public void MarkeActive()
        {
            Active = true;
        }

        public void MarkeInactive()
        {
            Active = false;
        }
    }
}
