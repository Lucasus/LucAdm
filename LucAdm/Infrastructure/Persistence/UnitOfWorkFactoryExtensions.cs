using System;

namespace LucAdm
{
    public static class UnitOfWorkFactoryExtensions
    {
        public static void Do(this UnitOfWorkFactory factory, Action<UnitOfWork> action)
        {
            factory.Create().Do(action);
        }

        public static T Do<T>(this UnitOfWorkFactory factory, Func<UnitOfWork, T> action)
        {
            return factory.Create().Do(action);
        }        
    }
}