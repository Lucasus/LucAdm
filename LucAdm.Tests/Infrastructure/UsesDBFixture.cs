using System;
using System.Data.Entity.Migrations;

namespace LucAdm.Tests
{
    public sealed class UsesDbFixture : IDisposable
    {
        public UsesDbFixture()
        {
            new DbMigrator(new MigrationConfiguration()).Update();
        }

        public void Dispose()
        {
        }
    }
}