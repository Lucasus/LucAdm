using LucAdm.DataGen;
using System.Data.Entity.Migrations;
using Xunit;

namespace LucAdm.Tests
{
    public class MigrationTests : IClassFixture<UsesDBFixture>
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
            migrator.Update("201503071318296_InitialCreate");

            // up to current
            migrator.Update();
        }
    }
}
