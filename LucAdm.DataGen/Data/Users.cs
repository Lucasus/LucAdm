using System.Collections.Generic;
using System.Linq;

namespace LucAdm.DataGen
{
    public class Users : Data<User>
    {
        [Environment(EnvironmentEnum.Dev, EnvironmentEnum.Test)] 
        public static User Admin = new User
        {
            UserName = "admin",
            HashedPassword = "adminPwd",
            Email = "admin@admin.com",
            Active = true
        };

        [Environment(EnvironmentEnum.Dev, EnvironmentEnum.Test)] 
        public static User User1 = new User
        {
            UserName = "Gandalf",
            HashedPassword = "gandalfPwd",
            Email = "gandalf@gandalf.com",
            Active = true
        };

        [Environment(EnvironmentEnum.Dev, EnvironmentEnum.Test)] 
        public static User User2 = new User
        {
            UserName = "Frodo",
            HashedPassword = "frodo",
            Email = "frodo@lucadm.com",
            Active = true
        };

        public override IEnumerable<User> GetGeneratedData(EnvironmentEnum environment)
        {
            if (environment == EnvironmentEnum.Dev || environment == EnvironmentEnum.Test)
            {
                return Enumerable.Range(1, 10).Select(i => new User
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