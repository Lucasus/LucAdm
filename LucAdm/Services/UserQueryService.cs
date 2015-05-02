using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace LucAdm
{
    public class UserQueryService
    {
        private readonly PersistenceContext _context;

        public UserQueryService(PersistenceContext context)
        {
            _context = context;
        }

        public UserDto GetById(Validated<int> id)
        {
            return _context.Users.Find(id.Value)
                .ToDto<UserDto>();
        }

        public UserDto GetByUserName(string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            return user != null ? user.ToDto<UserDto>() : null;
        }

        public UsersDto Get(GetUsersQuery query)
        {
            var sortColumn = string.IsNullOrEmpty(query.SortColumn) ? PropertyName.Get((User x) => x.Id) : query.SortColumn.FirstLetterToUpper();
            var sortType = query.SortType == "desc" ? " descending" : "";
            var users = _context.Users.Where(SearchCriteria(query.SearchTerm))
                .OrderBy(sortColumn + sortType)
                .Skip((query.Page - 1) * query.PageSize).Take(query.PageSize)
                .ToList();

            return new UsersDto()
            {
                List = users.Select(x => x.ToDto<UserItemDto>()).ToList(),
                Total = _context.Users.Count(SearchCriteria(query.SearchTerm))
            };
        }

        private Expression<Func<User, bool>> SearchCriteria(string searchTerm)
        {
            return x => x.UserName.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm);
        }
    }
}