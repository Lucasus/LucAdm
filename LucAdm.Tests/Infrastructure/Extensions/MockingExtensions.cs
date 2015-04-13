using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace LucAdm.Tests
{
    public static class MockingExtensions
    {
        public static T Where<T>(this T t, Action<T> action)
        {
            action(t);
            return t;
        }

        public static IList<T> AsList<T>(this ObjectBuilder<T> builder)
            where T: class
        {
            return new List<T>() { builder.Build() };
        }

        public static IDbSet<T> Returns<T>(this IDbSet<T> dbSet, IList<T> data) 
            where T : class
        {
            var queryableData = data.AsQueryable();
            dbSet.Provider.Returns(queryableData.Provider);
            dbSet.Expression.Returns(queryableData.Expression);
            dbSet.ElementType.Returns(queryableData.ElementType);
            dbSet.GetEnumerator().Returns(queryableData.GetEnumerator());
            return dbSet;
        }
    }
}
