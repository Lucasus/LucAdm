using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LucAdm
{
    public abstract class Repository<TEntity, TContext>
        where TEntity : Entity, new()
        where TContext : DbContext
    {
        protected readonly TContext Context;

        protected Repository(TContext context)
        {
            Context = context;
        }

        public virtual TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = new TEntity {Id = id};
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}