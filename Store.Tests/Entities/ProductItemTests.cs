using Store.Domain.Entities;
using Store.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Entities
{
    [TestClass]
    public class ProductItemTests
    {
        private readonly Custumer _custumer;
        private readonly Discount _discount;
        private readonly Product _product;


        public ProductItemTests()
        {
            _product = new Product("Farinha", 10);
            _discount = new Discount(10, DateTime.UtcNow.AddDays(5));
            _custumer = new Custumer(new Name("Bruno", "Neves"), new Email("neves@gmail.com"));

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_custumer, 0, _discount);
            order.AddItem(null!, 10);

            Assert.AreEqual(0, order.Items.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_a_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_custumer, 10, _discount);
            order.AddItem(_product, 0);

            Assert.AreEqual(0, order.Items.Count);
        }
    }
}
