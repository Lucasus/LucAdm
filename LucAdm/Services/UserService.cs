namespace LucAdm
{
    public class UserService
    {
        private UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public OperationResponse<int> CreateUser(CreateUserCommand command)
        {
            return command.IsValid(new CreateUserCommandValidator())
                .And(new UserNameUnique(userRepository) { UserName = command.UserName })
                .Then(() =>
            {
                return new OperationResponse<int>(1);
            });
        }
    }

}
