using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(PersistenceContext context) : base(context) { }
    }
}
