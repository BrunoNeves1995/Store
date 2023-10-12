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
    public class DicountTests
    {
        private readonly Custumer _custumer;
        private readonly Discount _discount;
        private readonly Product _product;


        public DicountTests()
        {
            _product = new Product("Farinha", 10);
            _discount = new Discount(10, DateTime.UtcNow.AddDays(5));
            _custumer = new Custumer(new Name("Bruno", "Neves"), new Email("neves@gmail.com"));

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_para_um_pedido_valido_seu_valor_deve_ser_110()
        {
            var expiredDiscount = new Discount(10, DateTime.UtcNow.AddDays(-5));
            var order = new Order(_custumer, 10, expiredDiscount);
            order.AddItem(_product, 10);

            Assert.AreEqual(110, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_para_um_pedido_valido_seu_valor_deve_ser_110()
        {
            // var InvalidDiscount = new Discount(-10, DateTime.UtcNow.AddDays(5));
            var order = new Order(_custumer, 10, null!);
            order.AddItem(_product, 10);

            Assert.AreEqual(110, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_reais_para_um_pedido_valido_seu_valor_deve_ser_90()
        {

            var order = new Order(_custumer, 0, _discount);
            order.AddItem(_product, 10);

            Assert.AreEqual(90, order.Total());
        }
    }
}
