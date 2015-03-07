using LucAdm.DataGen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    [TestClass]
    public abstract class DbTestBase
    {
        protected PersistenceContext dbContext;

        [TestInitialize]
        public void TestInitialize()
        {
            dbContext = new PersistenceContext();
            new DbDataDeleter(dbContext).DeleteAllData();
            new DataGenerator(dbContext, EnvironmentEnum.Test).Generate();
        }
    }
}
