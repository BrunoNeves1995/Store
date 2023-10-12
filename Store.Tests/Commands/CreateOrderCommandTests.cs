using Store.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        [TestMethod]
        [TestCategory("Command")]
        public void Dado_um_comando_invalido_o_peido_ñao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "";
            command.ZipeCode = "78280000";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.IsFalse(command.IsValid);
        }
    }
}
