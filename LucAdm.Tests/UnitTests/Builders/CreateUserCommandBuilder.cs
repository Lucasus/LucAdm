namespace LucAdm.Tests
{
    public class CreateUserCommandBuilder : ObjectBuilder<CreateUserCommand>
    {
        public CreateUserCommandBuilder Create()
        {
            Instance = new CreateUserCommand
            {
                AcceptedTermsOfUse = true,
                Email = "email@email.com",
                Password = "somePassword",
                RepeatedPassword = "somePassword",
                UserName = "userName"
            };
            return this;
        }

        public CreateUserCommandBuilder With(string userName = null, string password = null)
        {
            Instance.UserName = userName ?? Instance.UserName;
            Instance.Password = password ?? Instance.Password;
            return this;
        }
    }
}