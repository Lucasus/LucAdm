using System.Collections.Generic;
namespace LucAdm.Tests
{
    public abstract class ObjectBuilder<T>
        where T : class
    {
        protected T Instance { get; set; }

        public static implicit operator T(ObjectBuilder<T> builder)
        {
            return builder.Instance;
        }

        public T Build()
        {
            return Instance;
        }

        public IList<T> AsList()
        {
            return new List<T> { Build() };
        }
    }
}