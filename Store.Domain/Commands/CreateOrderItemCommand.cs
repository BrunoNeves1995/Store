using Flunt.Notifications;
using Store.Domain.Commands.Contract;
using Store.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Commands
{
    public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
    {
        public CreateOrderItemCommand(){}

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; } 
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(new CreateOrderItemCommandContract(this));
        }
    }
}
