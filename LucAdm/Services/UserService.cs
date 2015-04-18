namespace LucAdm
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OperationResponse<int> CreateUser(CreateUserCommand command)
        {
            return command.IsValid(new CreateUserCommandValidator())
                .And(new UserNameUnique(_userRepository) {UserName = command.UserName})
                .Then(() =>
                {
                    //_userRepository.Add(new User()
                    //{
                    //    Active = false,
                    //    Email = command.Email,
                    //    HashedPassword = command.Password,
                    //    UserName = command.UserName
                    //});
                    return new OperationResponse<int>(1);
                });
        }
    }
}