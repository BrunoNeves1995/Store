using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {   
        private readonly Custumer _custumer;
        private readonly Discount _discount;
        private readonly Product _product;


        public OrderTests()
        {
            _product = new Product("Farinha", 10);
            _discount = new Discount(10, DateTime.UtcNow.AddDays(5)); 
            _custumer = new Custumer(new Name("Bruno", "Neves"), new Email("neves@gmail.com"));

        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {


            var order = new Order(_custumer, 0, _discount);

            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_custumer, 0, _discount);
            Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardamndo_entrega()
        {
            var order = new Order(_custumer, 0, _discount);
            order.AddItem(_product, 10);
            order.Pay(90);
            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_o_pedido_não_pode_ser_cancelado()
        {
            var order = new Order(_custumer, 10, _discount);
            order.AddItem(_product, 10);
            order.Pay(100);
            order.Cancel();
            Assert.IsFalse(order.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_se_cancelado_o_status_do_pedido_deve_ser_aguardamndo_entrega()
        {
            var order = new Order(_custumer, 0, _discount);
            order.AddItem(_product, 10);
            order.Pay(90);
            order.Cancel();
            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            var order = new Order(_custumer, 0, _discount);
            order.AddItem(_product, 10);
            order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_100()
        {
            var order = new Order(_custumer, 10, _discount);
            order.AddItem(_product, 10);

            Assert.AreEqual(100, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_reais_com_10_de_desconto_o_valor_do_pedido_deve_ser_110()
        {
            var order = new Order(_custumer, 10, _discount);
            order.AddItem(_product, 10);
            Assert.AreEqual(100, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            var order = new Order(null!, 10, _discount);
            order.AddItem(_product, 10);
            Assert.IsFalse(order.IsValid);
        }
    }
}
