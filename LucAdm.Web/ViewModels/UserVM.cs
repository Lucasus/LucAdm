using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucAdm.Web
{
    public class UserVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}