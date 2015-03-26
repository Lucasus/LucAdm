using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;

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
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                       .Where(type => !String.IsNullOrEmpty(type.Namespace))
                       .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                            && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder); base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}
