using Store.Domain.Entities.Contracts;
using Store.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Price = product != null ? product.Price : 0;
            Quantity = quantity;

            AddNotifications(new CreateOrderItemContract(this));
        }

      

        public Product Product { get; private set; } = null!;
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }   

        public decimal SubTotal()
        {
            return Price * Quantity;
        }
    }
}
