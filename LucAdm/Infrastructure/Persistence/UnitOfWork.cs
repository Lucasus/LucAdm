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

        public void Cancel()
        {
            if (!Canceled)
            {
                Canceled = true;
            }
        }
    }
}