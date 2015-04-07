using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
