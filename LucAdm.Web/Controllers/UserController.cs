using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LucAdm.Web
{
    public class UserController : ApiController
    {
        public IList<UserVM> Get()
        {
            return new List<UserVM>()
            {
                new UserVM() { UserName = "Gandalf", Active = true },
                new UserVM() { UserName = "Gimli", Active = false },
                new UserVM() { UserName = "Legolas", Active = true },
                new UserVM() { UserName = "Frodo", Active = false },
            };
        }
    }
}
