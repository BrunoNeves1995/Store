using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Mocks
{
    public class FakeCustumerRepository : ICustumerRepository
    {
        public Custumer Get(string email)
        {
            if (email == "neves@gmail.com")
                return new Custumer(new Name("Bruno", "Neves"), new Email("neves@gmail.com"));

            return null!;
        }
    }
}
