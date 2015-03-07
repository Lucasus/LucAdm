using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.DataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PersistenceContext();
            new DbDataDeleter(context).DeleteAllData();
            new DbMigrator(new MigrationConfiguration()).Update();
            new DataGenerator(context, EnvironmentEnum.Dev).Generate();

            Console.ReadKey();
        }
    }
}
