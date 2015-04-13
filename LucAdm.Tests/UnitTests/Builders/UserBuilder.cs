using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    public class UserBuilder : ObjectBuilder<User>
    {
        public UserBuilder Create()
        {
            instance = new User()
            {
                UserName = "userName",
                Email = "email@email.com",
                Active = true,
            };
            return this;
        }

        public UserBuilder With(string userName = null, string email = null)
        {
            instance.UserName = userName ?? instance.UserName;
            instance.Email = email ?? instance.Email;
            return this;
        }
    }
}
