using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Contracts
{
    public class CreateOrderItemContract : Contract<OrderItem>
    {
        public CreateOrderItemContract(OrderItem orderItem)
        {
            Requires()
                .IsNotNull(orderItem.Product, "OrderItem.Product", "Produto inválido")
                 .IsGreaterOrEqualsThan(orderItem.Quantity, 1, "Order.DeliveryFree", "A quantidade desse produto deve ser maior que zero");
        }
    }
}
