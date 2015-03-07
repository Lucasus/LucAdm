using System.Collections.Generic;
using System.Linq;

namespace LucAdm.DataGen
{
    public class Users : Data<User>
    {
        [Environment(EnvironmentEnum.Dev, EnvironmentEnum.Test)]
        public static User Admin = new User { UserName = "admin", HashedPassword = "adminPwd", Email = "admin@admin.com" };

        public override IList<User> GetData(EnvironmentEnum environment)
        {
            if(environment == EnvironmentEnum.Dev)
            {
                return Enumerable.Range(1, 10).Select(x => new User() { UserName = "User" + x, Email = "email@email" + x }).ToList();
            }
            return null;
        }

    }
}
