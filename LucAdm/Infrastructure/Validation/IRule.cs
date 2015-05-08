using System.Threading.Tasks;

namespace LucAdm
{
    public interface IRule
    {
        string Name { get; }
        string ErrorMessage { get; }
        Task<bool> CheckAsync();
    }
}