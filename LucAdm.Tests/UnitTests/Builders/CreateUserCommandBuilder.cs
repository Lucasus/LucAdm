using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    public class CreateUserCommandBuilder
    {
        private CreateUserCommand command;

        public CreateUserCommandBuilder Create()
        {
            command = new CreateUserCommand()
            {
                AcceptedTermsOfUse = true,
                Email = "email@email.com",
                Password = "somePassword",
                RepeatedPassword = "somePassword",
                UserName = "userName",
            };
            return this;
        }

        public CreateUserCommandBuilder With(string userName = null, string password = null)
        {
            command.UserName = userName ?? command.UserName;
            command.Password = password ?? command.Password;
            return this;
        }

        public CreateUserCommand Build()
        {
            return command;
        }
    }
}
