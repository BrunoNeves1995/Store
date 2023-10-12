using Store.Domain.ValueObjects;
using Store.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Custumer : Entity
    {

        protected Custumer() { }

        public Custumer(Name name, Email email)
        {
            Name = name;
            Email = email;

            AddNotifications(name, email);
        }




        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
    }
}
