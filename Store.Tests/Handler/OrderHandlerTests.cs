using Store.Domain.Commands;
using Store.Domain.Handler;
using Store.Domain.Repositories;
using Store.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Handler
{
    [TestClass]
    public class OrderHandlerTests
    {
        private readonly ICustumerRepository _custumerRepository;
        private readonly IDeliveryFreeRepository _deliveryFreeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandlerTests()
        {
            _custumerRepository = new FakeCustumerRepository();
            _deliveryFreeRepository = new FakeDeliveryFreeRepository();
            _discountRepository = new FakeDiscountRepository();
            _productRepository = new FakeProductRepository();
            _orderRepository = new FakeOrderRepository();
        }


        [TestMethod]
        [TestCategory("Handler")]
        public void Dado_um_cliente_inexistente_o_pedido_não_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "nevees@gmail.com";
            command.ZipeCode = "78280000";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(
                 _custumerRepository,
                 _deliveryFreeRepository,
                 _discountRepository,
                 _productRepository,
                 _orderRepository);

            handler.Handle(command);
            Assert.IsFalse(handler.IsValid);
        }


        [TestMethod]
        [TestCategory("Hander")]
        public void Dado_um_cep_invalido_o_pedido_não_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "neves@gmail.com";
            command.ZipeCode = "782890000";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));


            var handler = new OrderHandler(
                 _custumerRepository,
                 _deliveryFreeRepository,
                 _discountRepository,
                 _productRepository,
                 _orderRepository);

            handler.Handle(command);
            Assert.IsFalse(handler.IsValid);
        }

        [TestMethod]
        [TestCategory("Hander")]
        public void Dado_um_promocode_inexstente_o_pedido_deve_ser_gerado_normalmente()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "neves@gmail.com";
            command.ZipeCode = "782800000";
            command.PromoCode = "123456780";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));


            var handler = new OrderHandler(
                 _custumerRepository,
                 _deliveryFreeRepository,
                 _discountRepository,
                 _productRepository,
                 _orderRepository);

            handler.Handle(command);
            Assert.IsFalse(handler.IsValid);
        }

        [TestMethod]
        [TestCategory("Hander")]
        public void Dado_um_pedido_sem_item_o_mesmo_não_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "neves@gmail.com";
            command.ZipeCode = "78280000";
            command.PromoCode = "12345678";
            command.Items.Add(null!);
            command.Items.Add(null!);

            var handler = new OrderHandler(
                 _custumerRepository,
                 _deliveryFreeRepository,
                 _discountRepository,
                 _productRepository,
                 _orderRepository);

            handler.Handle(command);
            Assert.IsFalse(handler.IsValid);
        }

        [TestMethod]
        [TestCategory("Hander")]
        public void Dado_um_comando_invalido_o_pedido_não_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "";
            command.ZipeCode = "78280000";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(
                 _custumerRepository,
                 _deliveryFreeRepository,
                 _discountRepository,
                 _productRepository,
                 _orderRepository);

            handler.Handle(command);

            Assert.IsFalse(handler.IsValid);
        }

        [TestMethod]
        [TestCategory("Hander")]
        public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "neves@gmail.com";
            command.ZipeCode = "78280000";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(
                 _custumerRepository,
                 _deliveryFreeRepository,
                 _discountRepository,
                 _productRepository,
                 _orderRepository);

            handler.Handle(command);
            Assert.IsTrue(handler.IsValid);
        }
    }
}
