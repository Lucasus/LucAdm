namespace LucAdm
{
    public class UpdateUserCommand : IValidatable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}