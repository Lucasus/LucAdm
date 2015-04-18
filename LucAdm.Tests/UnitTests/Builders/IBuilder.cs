namespace LucAdm.Tests
{
    public abstract class ObjectBuilder<T>
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
    }
}