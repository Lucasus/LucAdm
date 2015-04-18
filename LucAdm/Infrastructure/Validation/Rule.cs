namespace LucAdm
{
    public abstract class Rule
    {
        public string Name { get; protected set; }
        public string Message { get; protected set; }
        public abstract bool Check();
    }
}