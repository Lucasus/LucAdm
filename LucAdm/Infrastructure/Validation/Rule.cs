namespace LucAdm
{
    public abstract class Rule
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public abstract bool Check();
    }
}