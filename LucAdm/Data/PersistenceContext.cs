using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LucAdm
{
    public class PersistenceContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public PersistenceContext()
            : base()
        {
            Database.SetInitializer<PersistenceContext>(new MigrateDatabaseToLatestVersion<PersistenceContext, MigrationConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
