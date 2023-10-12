using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Utils;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Domain.Handler
{
    public class OrderHandler : 
        Notifiable<Notification>,
        IHandler<CreateOrderCommand, CommandResult>
    {   
        private readonly ICustumerRepository  _custumerRepository;
        private readonly IDeliveryFreeRepository _deliveryFreeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderHandler(
            ICustumerRepository custumerRepository, 
            IDeliveryFreeRepository deliveryFreeRepository, 
            IDiscountRepository discountRepository, 
            IProductRepository productRepository, 
            IOrderRepository orderRepository)
        {
            _custumerRepository = custumerRepository;
            _deliveryFreeRepository = deliveryFreeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public CommandResult Handle(CreateOrderCommand command)
        {
            // fail fast validate
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar asssinatura", command.Notifications);
            }


            // recuperando o cliente já esta cadastrado
            var custumer = _custumerRepository.Get(command.Custumer);


            // calcular a taxa de entrega
            var deliveryFree = _deliveryFreeRepository.Get(command.ZipeCode);

            // obtendo o cupom de desconto
            var discount = _discountRepository.Get(command.PromoCode);


            // gerar os pedidos
            var products = _productRepository.Get(ExtractsGuids.Extract(command.Items)).ToList();
            var order = new Order(custumer, deliveryFree, discount);


            // relacionamentos
            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product!, item.Quantity);
            }


            // agrupar as validações
            AddNotifications(order.Notifications);


            // checar as notificaçoes
            if (!IsValid)
                return new CommandResult(false, "Falha ao gerar o pedido", Notifications);


            // salvar as informações
            _orderRepository.Save(order);


            // enviar o pedido e-mail


            // retorna as informações 
            return new CommandResult(true, $"Peido {order.Number } foi realizado com sucesso", order);
        }
    }
}
