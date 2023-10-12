using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Commands.Contract
{
    public class CreateOrderItemCommandContract : Contract<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandContract(CreateOrderItemCommand command)
        {
            Requires()
                .IsNull(command.Product, "CreateOrderItemCommand.Product", "Item não pode ser nulo")
                .IsLowerOrEqualsThan(command.Product.ToString(), 32, "CreateOrderItemCommand.Product", "Produto é invalido")
                .IsGreaterThan(command.Quantity, 0, "CreateOrderItemCommand.Quantity", "Quantidade não pode ser menor que zero");
        }
    }
}
