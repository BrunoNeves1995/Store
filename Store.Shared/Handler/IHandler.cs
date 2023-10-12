using Store.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Shared.Handler
{
    public interface IHandler<T, out R>
         where T : ICommand
         where R : ICommandResult
    {
        R Handle(T command);
    }
}
