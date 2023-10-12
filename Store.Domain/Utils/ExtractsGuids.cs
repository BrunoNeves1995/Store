using Store.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Utils
{
    public class ExtractsGuids 
    {
        public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> Items)
        {
            var guids = new List<Guid>();
              foreach (var item in Items)
                  guids.Add(item.Product);
                
            return guids;
        }
    }
}
