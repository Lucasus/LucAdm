using System;
using System.Data.Entity;
using System.Threading.Tasks;

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
        public Task Do<T>(Func<T> action)
        {
            return Do(work => action());
        }

        /// <summary>
        /// Executes action as a unit of work
        /// </summary>
        public Task Do(Action action)
        {
            return Do(work => action());
        }

        /// <summary>
        /// Executes action as a unit of work
        /// </summary>
        public Task Do(Action<UnitOfWork> action)
        {
            return Create().Do(action);
        }

        /// <summary>
        /// Executes action as a unit of work
        /// </summary>
        public Task<T> Do<T>(Func<UnitOfWork, T> action)
        {
            return Create().Do(action);
        }
    }
}