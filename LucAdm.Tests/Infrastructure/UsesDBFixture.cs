using System;
using System.Data.Entity.Migrations;

namespace LucAdm.Tests
{
    public class UsesDBFixture : IDisposable
    {
        public UsesDBFixture()
        {
                new DbMigrator(new MigrationConfiguration()).Update();
        }

        public void Dispose()
        {
        }
    }
}
