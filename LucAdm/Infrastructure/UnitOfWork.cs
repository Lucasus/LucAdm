using LucAdm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendsTracker.Infrastructure
{
    public class UnitOfWork
    {
        private PersistenceContext context;
        private bool canceled = false;

        public bool Canceled { get { return canceled; } }

        public UnitOfWork(PersistenceContext context)
        {
            this.context = context;
        }

        public void Do(Action<UnitOfWork> work)
        {
            try
            {
                work(this);
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
