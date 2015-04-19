using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

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
            var sortColumn = string.IsNullOrEmpty(query.SortColumn) ? PropertyName.Get((User x) => x.Id) : query.SortColumn.FirstLetterToUpper();
            var sortType = query.SortType == "desc" ? " descending" : "";
            var users = Context.Users.Where(x => x.UserName.Contains(query.SearchTerm) || string.IsNullOrEmpty(query.SearchTerm))
                .OrderBy(sortColumn + sortType)
                .Skip((query.Page - 1) * query.PageSize).Take(query.PageSize)
                .ToList();

            return users;            
        }

        public int Count(string searchTerm)
        {
            return Context.Users.Count(x => x.UserName.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm));
        }
    }
}