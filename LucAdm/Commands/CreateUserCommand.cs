namespace LucAdm
{
    public class UpdateUserCommand : IValidatable
    {
        public Validated<int> Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}