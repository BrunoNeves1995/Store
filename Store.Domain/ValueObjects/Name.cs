using Store.Domain.ValueObjects.Contracts;
using Store.Shared.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        protected Name(){}

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new CreateNameContract(this));
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
