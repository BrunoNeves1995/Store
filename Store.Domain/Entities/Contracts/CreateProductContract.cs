using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Contracts
{
    public class CreateProductContract : Contract<Product>
    {
        public CreateProductContract(Product product) 
        {
            Requires()
                .IsNotNullOrEmpty(product.Title, "Product.Title", "Titulo é obrigatório")
                .IsLowerOrEqualsThan(3, product.Title.Length, "Product.Title", "Titulo precisa ter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(45, product.Title.Length, "Product.Title", "titulo precisa ter no maximo 45 caracteres")

                .IsGreaterThan(product.Price, 0, "Product.Price", "Preço deve ser maior que zero");


        }
    }
}
