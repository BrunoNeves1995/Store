using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Mocks
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {   

            IList<Product> products = new List<Product>();

         
  
            products.Add(new Product("Produto 01", 10));
            products.Add(new Product("Produto 02", 10));
            products.Add(new Product("Produto 03", 10));

            var pro04 = new Product("Produto 04", 10);
            pro04.MarkeInactive();
            products.Add(pro04);    

            var prod05 = new Product("Produto 05", 10);
            prod05.MarkeInactive();
            products.Add(prod05);

            return products;
        }
    }
}
