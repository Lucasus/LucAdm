namespace LucAdm.Tests
{
    public class CreateUserCommandBuilder : ObjectBuilder<CreateUserCommand>
    {
        public CreateUserCommandBuilder Create()
        {
            instance = new CreateUserCommand()
            {
                AcceptedTermsOfUse = true,
                Email = "email@email.com",
                Password = "somePassword",
                RepeatedPassword = "somePassword",
                UserName = "userName",
            };
            return this;
        }

        public CreateUserCommandBuilder With(string userName = null, string password = null)
        {
            instance.UserName = userName ?? instance.UserName;
            instance.Password = password ?? instance.Password;
            return this;
        }
    }
}
