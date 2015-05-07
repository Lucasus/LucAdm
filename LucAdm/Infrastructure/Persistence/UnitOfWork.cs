using System;
using System.Data.Entity;
using System.Threading.Tasks;

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

        public async Task Do(Action<UnitOfWork> action)
        {
            try
            {
                action(this);
                if (!Canceled)
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
            }   
            catch (Exception)
            {
                Canceled = true;
                throw;
            }
        }

        public async Task<T> Do<T>(Func<UnitOfWork, T> action)
        {
            try
            {
                var result = action(this);
                if (!Canceled)
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
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