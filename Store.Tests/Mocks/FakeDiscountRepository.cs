using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Mocks
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string codigoDiscount)
        {
            if (codigoDiscount == "12345678")
                return new Discount(10, DateTime.UtcNow.AddDays(5));

            if (codigoDiscount == "11111111")
                return new Discount(10, DateTime.UtcNow.AddDays(-5));

            return new Discount(0, DateTime.UtcNow.AddDays(-5));
        }
    }
}
