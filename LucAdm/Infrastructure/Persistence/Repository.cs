using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LucAdm
{
    public abstract class Repository<T>
        where T : Entity, new()
    {
        protected PersistenceContext Context;

        protected Repository(PersistenceContext context)
        {
            Context = context;
        }

        public virtual IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = new T {Id = id};
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}