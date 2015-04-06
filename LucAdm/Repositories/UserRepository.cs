using System.Linq;

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
