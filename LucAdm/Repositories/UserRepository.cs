using System.Collections.Generic;
using System.Linq;

namespace LucAdm
{
    public sealed class UserRepository : Repository<User, PersistenceContext>
    {
        public UserRepository(PersistenceContext context) : base(context)
        {
        }

        public User GetByUserName(string userName)
        {
            return Context.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public IEnumerable<User> Get(GetUsersQuery query)
        {
            var users = Context.Users.Where(x => x.UserName.Contains(query.SearchTerm) || string.IsNullOrEmpty(query.SearchTerm));
            switch (query.SortType)
            {
                case "userName_asc":
                    users = users.OrderBy(x => x.UserName);
                    break;
                case "userName_desc":
                    users = users.OrderByDescending(x => x.UserName);
                    break;
                default:
                    users = users.OrderBy(x => x.Id);
                    break;
            }
            users = users.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
            return users.ToList();            
        }
    }
}