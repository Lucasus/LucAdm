using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LucAdm
{
    public abstract class Repository<T>
        where T: Entity, new()
    {
        protected PersistenceContext context;

        public Repository(PersistenceContext context)
        {
            this.context = context;
        }

        public virtual IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = new T() { Id = id };
            context.Entry(entity).State = EntityState.Deleted;
        }

    }
}
