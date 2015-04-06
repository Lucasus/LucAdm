namespace LucAdm
{
    public interface IValidatable { }

    public class CreateUserCommand : IValidatable
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public Validated<bool> AcceptedTermsOfUse { get; set; }
    }
}
