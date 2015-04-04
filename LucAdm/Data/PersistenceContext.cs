using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            foreach (var type in getMappingTypes())
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<Type> getMappingTypes()
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                       .Where(type => !String.IsNullOrEmpty(type.Namespace))
                       .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                            && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            return typesToRegister;
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
