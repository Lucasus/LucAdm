using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LucAdm
{
    public class PropertyName
    {
        public static string Get<TSource, TProperty>(Expression<Func<TSource, TProperty>> property)
        {
            return ((property.Body as MemberExpression).Member as PropertyInfo).Name;
        }
    }
}