using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Mocks
{
    public class FakeDeliveryFreeRepository : IDeliveryFreeRepository
    {
        public decimal Get(string zipCode)
        {
            if (zipCode == "78280000")
                return 10;

            return 0;
        }
    }
}
