using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    public static class MockingExtensions
    {
        public static T Where<T>(this T t, Action<T> action)
        {
            action(t);
            return t;
        }
    }
}
