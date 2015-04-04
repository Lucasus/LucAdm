using System.Collections.Generic;
using System.Linq;

namespace LucAdm.DataGen
{
    public class Users : Data<User>
    {
        [Environment(EnvironmentEnum.Dev, EnvironmentEnum.Test)]
        public static User Admin = new User { UserName = "admin", HashedPassword = "adminPwd", Email = "admin@admin.com", Active = true };

        public override IEnumerable<User> GetData(EnvironmentEnum environment)
        {
            if(environment == EnvironmentEnum.Dev)
            {
                return Enumerable.Range(1, 10).Select(i => new User() 
                { 
                    UserName = "User" + i, 
                    Email = "email@email" + i, 
                    Active = i%2 == 0 
                });
            }
            return null;
        }

    }
}
