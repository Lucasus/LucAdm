using System;
using System.Data.Entity;

namespace LucAdm
{
    public class UnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            Canceled = false;
            _context = context;
        }

        public bool Canceled { get; private set; }

        public void Do(Action<UnitOfWork> action)
        {
            Do<object>((work) =>
            {
                action(work);
                return null;
            });
        }

        public T Do<T>(Func<UnitOfWork, T> action)
        {
            try
            {
                var result = action(this);
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