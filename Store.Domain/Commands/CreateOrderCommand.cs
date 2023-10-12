using Flunt.Notifications;
using Store.Domain.Commands.Contract;
using Store.Domain.Entities;
using Store.Shared.Commands;
using Store.Shared.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Commands
{
    public class CreateOrderCommand :
        Notifiable<Notification>,
        ICommand
    {   

        public CreateOrderCommand() 
        {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(string custumer, string zipeCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Custumer = custumer;
            ZipeCode = zipeCode;
            PromoCode = promoCode;
            Items = items;
        }

        public string Custumer { get; set; } = null!;
        public string ZipeCode { get; set; } = null!;
        public string PromoCode { get; set; } = string.Empty;
        public IList<CreateOrderItemCommand> Items { get; set; }

        public bool ItemValidate()
        {
            foreach (var item in Items)
            {
                if (item is not null)
                {
                    return true;
                }
            }

            return false;
        }

        public void Validate()
        {
            AddNotifications(new CreateOrderCommandContract(this));
        }
    }
}
