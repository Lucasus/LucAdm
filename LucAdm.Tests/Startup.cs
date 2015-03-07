using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    [TestClass]
    public static class Startup
    {
        [AssemblyInitialize]
        public static void InitializeTestData(TestContext context)
        {
            // Apply latest migrations
            new DbMigrator(new MigrationConfiguration()).Update();
        }
    }
}
