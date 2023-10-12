using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Contracts
{
    public class CreateDiscountContrac : Contract<Discount>
    {
        public CreateDiscountContrac(Discount discount) 
        {
            Requires()
                .IsNotNullOrEmpty(discount.Amount.ToString(), "Discount.Amount", "Desconto é invalido")
                .IsGreaterOrEqualsThan(discount.Amount, 0, "Discount.Amount", "Valor não pode ser menor que zero")
                .IsTrue(discount.IsValide(), "Discount.expireDate", "Data inválida");
        }

    }
}
