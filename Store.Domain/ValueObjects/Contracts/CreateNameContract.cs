using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.ValueObjects.Contracts
{
    public class CreateNameContract : Contract<Name>
    {
        public CreateNameContract(Name name)
        {
            Requires()
                .IsNotNullOrEmpty(name.FirstName, "Name.FirstName", "Nome é obrigatório")
                .IsLowerOrEqualsThan(3, name.FirstName.Length, "Name.FirstName", "Nome precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, name.FirstName.Length, "Name.FirstName", "Nome precisa ter no maximo 20 caracteres")

                .IsNotNullOrEmpty(name.LastName, "Name.LastName", "Sobre nome é obrigatório")
                .IsLowerOrEqualsThan(3, name.LastName.Length, "Name.LastName", "Nome precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(20, name.LastName.Length, "Name.LastName", "Nome precisa ter no maximo 20 caracteres");
        }
    }
}
