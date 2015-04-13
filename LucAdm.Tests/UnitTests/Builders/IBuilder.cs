namespace LucAdm.Tests
{
    public abstract class ObjectBuilder<T>
    {
        protected T instance;

        public static implicit operator T(ObjectBuilder<T> builder)
        {
            return builder.instance;
        }

        public T Build()
        {
            return instance;
        }

    }
}
