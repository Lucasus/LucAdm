namespace LucAdm
{
    public interface IRule
    {
        string Name { get; }
        string ErrorMessage { get; }
        bool Check();
    }
}