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

        public virtual User GetByUserName(string userName)
        {
            return context.Users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
