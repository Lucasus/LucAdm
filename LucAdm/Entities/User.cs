using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm
{
    public class User : Entity
    {
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual bool Active { get; set; }
    }
}
