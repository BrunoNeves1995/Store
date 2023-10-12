using Store.Domain.Entities;
using Store.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private readonly IList<Product> _products;

        public ProductQueriesTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto 01", 10));
            _products.Add(new Product("Produto 02", 10));
            _products.Add(new Product("Produto 03", 10));

            var pro04 = new Product("Produto 04", 10);
            pro04.MarkeInactive();
            _products.Add(pro04);

            var prod05 = new Product("Produto 05", 10);
            prod05.MarkeInactive();
            _products.Add(prod05);

        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_uma_consulta_de_produtos_ativos_deve_retorna_3_produtos() 
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_uma_consulta_de_produtos_inativo_deve_retorna_2_produtos()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(2, result.Count());
        }
    }
}
