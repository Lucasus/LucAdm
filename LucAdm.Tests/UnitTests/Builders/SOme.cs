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

        public static UserService UserService(PersistenceContext context = null)
        {
            return new UserService(new Repository<User>(context), new UserQueryService(context), null);
        }
    }
}