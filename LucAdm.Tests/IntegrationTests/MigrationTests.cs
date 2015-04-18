using System.Data.Entity.Migrations;
using LucAdm.DataGen;
using Xunit;

namespace LucAdm.Tests
{
    public class MigrationTests : IClassFixture<UsesDbFixture>
    {
        [Theory]
        [InlineData(EnvironmentEnum.Test)]
        [InlineData(EnvironmentEnum.Dev)]
        [Trait("Category", "Integration")]
        public void Migrations_Should_Work_Both_Ways(EnvironmentEnum environment)
        {
            var migrator = new DbMigrator(new MigrationConfiguration());

            migrator.Update();
            new PersistenceContext().ResetDbState(environment);

            // back to 0
            migrator.Update("0");

            // up to current
            migrator.Update();
        }
    }
}