using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Contracts
{
    public class CreateOrderContract : Contract<Order>
    {
        public CreateOrderContract(Order order) 
        {
            Requires()
                .IsNotNull(order.Discount, "Order.Custumer", "Desconto inválido")
                .IsNotNull(order.Custumer, "Order.Custumer", "Cliente inválido")
                .IsGreaterOrEqualsThan(order.DeliveryFree, 0, "Order.DeliveryFree", "A taxa de entrega não pode ser menor que zero");
        }
    }
}
