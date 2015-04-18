namespace LucAdm.Tests
{
    public static class Some
    {
        public static CreateUserCommandBuilder CreateUserCommand()
        {
            return new CreateUserCommandBuilder().Create();
        }

        public static UserBuilder User()
        {
            return new UserBuilder().Create();
        }
    }
}