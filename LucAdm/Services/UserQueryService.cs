using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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
            return _context.Users.Find(id.Value).ToDto<UserDto>();
        }

        public int CountByUserName(string userName)
        {
            return _context.Users.Count(x => x.UserName == userName);
        }

        public int CountByEmail(string email)
        {
            return _context.Users.Count(x => x.Email == email);
        }

        public UsersDto Get(GetUsersQuery query)
        {
            var sortColumn = string.IsNullOrEmpty(query.SortColumn) 
                ? PropertyName.Get((User x) => x.Id) 
                : query.SortColumn.FirstLetterToUpper();

            var sortType = query.SortType == "desc" ? " descending" : "";

            var users = _context.Users.Where(SearchCriteria(query.SearchTerm))
                .OrderBy(sortColumn + sortType)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Project().To<UserItemDto>()
                .ToList();

            return new UsersDto()
            {
                List = users,
                Total = _context.Users.Count(SearchCriteria(query.SearchTerm))
            };
        }

        private Expression<Func<User, bool>> SearchCriteria(string searchTerm)
        {
            return x => x.UserName.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm);
        }
    }
}