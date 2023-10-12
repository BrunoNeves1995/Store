using Store.Domain.Entities.Contracts;
using Store.Domain.Enums;
using Store.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;

        protected Order() 
        {
            _items = new List<OrderItem>();
        }
        public Order(Custumer custumer, decimal deliveryFree, Discount discount)
        {
            Custumer = custumer;
            Date = DateTime.UtcNow;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            Status = EOrderStatus.WaitingPayment;
            DeliveryFree = deliveryFree;
            Discount = discount;
            _items = new List<OrderItem>();

            AddNotifications(new CreateOrderContract(this));
          
        }


        public Custumer Custumer { get; private set; } = null!;
        public DateTime Date { get; private set; }
        public string Number { get; private set; } = null!;
        public EOrderStatus Status { get; private set; }
        public decimal DeliveryFree { get; private set; }
        public Discount Discount { get; private set; } = null!;
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();

        public void AddItem(Product product, int qunatity)
        {
            OrderItem item = new OrderItem(product, qunatity);
            if (item.IsValid)
                _items.Add(item);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in _items)
            {
                total += item.SubTotal();
            }

            total += DeliveryFree;
            total -= Discount is not null ? Discount.Value() : 0;

            return total;
        }

        public void Pay(decimal amount)
        {
            if (amount == Total())
            {
                this.Status = EOrderStatus.WaitingDelivery;
            }
        }

        public void Cancel()
        {
            if (this.Status == EOrderStatus.WaitingDelivery)
                AddNotification("Order.Cancel", "O Pedido não pode ser cancelado, pois o pedido esta aguardando entrega");
            else
                this.Status = EOrderStatus.Canceled;
        }
    }
}
