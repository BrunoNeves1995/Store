using Store.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            this.data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public object data { get; set; } = null!;
    }
}
