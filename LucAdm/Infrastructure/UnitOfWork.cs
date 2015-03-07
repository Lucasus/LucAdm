using System;
using System.Data.Entity;

namespace LucAdm
{
    public class UnitOfWork
    {
        private DbContext context;
        private bool canceled = false;

        public bool Canceled { get { return canceled; } }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Do(Action work)
        {
            try
            {
                work();
                if (!canceled)
                {
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                canceled = true;
                throw;
            }
        }

        public void Cancel()
        {
            if (!canceled)
            {
                canceled = true;
            }
        }
    }
}
