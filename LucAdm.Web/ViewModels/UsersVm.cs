using System.Collections.Generic;

namespace LucAdm.Web
{
    public class UsersVm
    {
        public IList<UserItemVm> List { get; set; }
        public int Total { get; set; }
    }
}