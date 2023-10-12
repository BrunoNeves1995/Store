using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Commands.Contract
{
    public class CreateOrderCommandContract : Contract<CreateOrderCommand>
    {
        public CreateOrderCommandContract(CreateOrderCommand command)
        {
            Requires()
                .IsNotNullOrEmpty(command.PromoCode, "CreateOrderCommand.PromoCode", "Desconto é invalido")
                .IsTrue(command.ItemValidate(), "CreateOrderCommand.Items", "Item é invalido")
                .IsGreaterOrEqualsThan(command.Custumer.Length, 5, "CreateOrderCommand.Custumer", "Nome precisa ter no minimo 5 caracteres")
                .IsGreaterOrEqualsThan(20, command.Custumer.Length, "CreateOrderCommand.Custumer", "Nome precisa ter no maximo 20 caracteres")
                .IsGreaterOrEqualsThan(8, command.ZipeCode.Length, "CreateOrderCommand.Custumer", "CEP precisa ter no minimo 8 caracteres")
                .IsGreaterOrEqualsThan(command.ZipeCode, 8, "CreateOrderCommand.Custumer", "CEP precisa ter no maximo 8 caracteres");
        }
    }
}
