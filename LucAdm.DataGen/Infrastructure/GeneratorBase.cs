using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace LucAdm.DataGen
{
    public abstract class GeneratorBase
    {
        private DbContext context;
        
        public EnvironmentEnum Environment { get; private set; }


        public GeneratorBase(DbContext context, EnvironmentEnum environment)
        {
            this.context = context;
            this.Environment = environment;
        }

        public void Save<T>(Data<T> data)
            where T: Entity, new()
        {
            var entities = data.GetType()
                          .GetFields(BindingFlags.Public | BindingFlags.Static)
                          .Where(field => 
                          {
                              if(field.FieldType != typeof(T))
                              {
                                  return false;
                              }

                              var envAttribute = field.GetCustomAttributes<EnvironmentAttribute>().FirstOrDefault();
                              if (envAttribute != null)
                              {
                                  return envAttribute.Environments.Any(env => env == this.Environment || env == EnvironmentEnum.All);
                              }
                              return true; 
                          })
                          .Select(prop => (T)prop.GetValue(null)).ToList();

            var additionalEntites = data.GetData(Environment);
            if (additionalEntites != null)
            {
                entities = entities.Union(additionalEntites).ToList();
            }

            foreach (var ent in entities)
            {
                context.Set<T>().Add(ent);
            }
            Console.Write("Creating " + typeof(T).Name + "... ");
            context.SaveChanges();
            Console.WriteLine(" DONE");
        }
    }
}
