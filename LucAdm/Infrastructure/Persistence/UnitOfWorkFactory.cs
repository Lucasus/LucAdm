using System;
using System.Data.Entity;

namespace LucAdm
{
    public class UnitOfWorkFactory
    {
        private readonly DbContext _context;

        public UnitOfWorkFactory(DbContext context)
        {
            _context = context;
        }

        public UnitOfWork Create()
        {
            return new UnitOfWork(_context);
        }

        public void Do(Action<UnitOfWork> action)
        {
            Create().Do(action);
        }

        public T Do<T>(Func<UnitOfWork, T> action)
        {
            return Create().Do(action);
        }
    }
}