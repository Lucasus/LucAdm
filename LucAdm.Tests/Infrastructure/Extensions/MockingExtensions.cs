using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LucAdm.Tests
{
    public static class MockingExtensions
    {
        public static DbSet<T> AsMock<T>(this IList<T> data)
             where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = Substitute.For<DbSet<T>, IQueryable<T>>();

            ((IQueryable<T>)mockSet).Provider.Returns(queryableData.Provider);
            ((IQueryable<T>)mockSet).Expression.Returns(queryableData.Expression);
            ((IQueryable<T>)mockSet).ElementType.Returns(queryableData.ElementType);
            ((IQueryable<T>)mockSet).GetEnumerator().Returns(queryableData.GetEnumerator());

            return mockSet;
        }
 
    }
}