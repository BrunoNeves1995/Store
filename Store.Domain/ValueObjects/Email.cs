using Store.Domain.ValueObjects.Contracts;
using Store.Shared.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        protected Email(){}

        public Email(string address)
        {
            Address = address;

            AddNotifications(new CreateEmailContract(this));
        }

        public string Address { get; private set; } = string.Empty;

       
    }
}
