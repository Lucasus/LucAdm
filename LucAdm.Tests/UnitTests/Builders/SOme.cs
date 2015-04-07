using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    public static class Some
    {
        public static CreateUserCommandBuilder CreateUserCommand()
        {
            return new CreateUserCommandBuilder().Create();
        }

    }
}
