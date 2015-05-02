using System.Collections.Generic;

namespace LucAdm
{
    public class UsersDto
    {
        public IList<UserItemDto> List { get; set; }
        public int Total { get; set; }
    }
}