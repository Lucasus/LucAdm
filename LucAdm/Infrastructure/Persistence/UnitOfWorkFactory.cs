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

        /// <summary>
        /// Executes action as a unit of work
        /// </summary>
        public T Do<T>(Func<T> action)
        {
            return Do(work => action());
        }

        /// <summary>
        /// Executes action as a unit of work
        /// </summary>
        public void Do(Action action)
        {
            Do(work => action());
        }

        /// <summary>
        /// Executes action as a unit of work
        /// </summary>
        public void Do(Action<UnitOfWork> action)
        {
            Create().Do(action);
        }

        /// <summary>
        /// Executes action as a unit of work
        /// </summary>
        public T Do<T>(Func<UnitOfWork, T> action)
        {
            return Create().Do(action);
        }
    }
}