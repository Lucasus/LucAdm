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
    }

    public class UnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            Canceled = false;
            _context = context;
        }

        public bool Canceled { get; private set; }

        public void Do(Action<UnitOfWork> work)
        {
            try
            {
                work(this);
                if (!Canceled)
                {
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                Canceled = true;
                throw;
            }
        }

        public T Do<T>(Func<UnitOfWork, T> work)
        {
            try
            {
                var result = work(this);
                if (!Canceled)
                {
                    _context.SaveChanges();
                }
                return result;
            }
            catch (Exception)
            {
                Canceled = true;
                throw;
            }
        }

        public void Cancel()
        {
            if (!Canceled)
            {
                Canceled = true;
            }
        }
    }
}