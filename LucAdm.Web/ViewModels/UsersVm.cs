using System.Collections.Generic;

namespace LucAdm.Web
{
    public class UsersVm
    {
        public IList<UserVm> List { get; set; }
        public int Total { get; set; }
    }
}