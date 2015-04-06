using LucAdm;
using System.Data.Entity.Migrations;

public sealed class MigrationConfiguration : DbMigrationsConfiguration<PersistenceContext>
{
    public MigrationConfiguration()
    {
        AutomaticMigrationsEnabled = false;
        MigrationsDirectory = @"Data\Migrations";
        ContextKey = "LucAdm.PersistenceContext";
    }


    protected override void Seed(PersistenceContext context)
    {
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
    }
}
