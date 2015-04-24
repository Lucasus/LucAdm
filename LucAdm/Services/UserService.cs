namespace LucAdm
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public UserService(UserRepository userRepository, UnitOfWorkFactory unitOfWorkFactory)
        {
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public OperationResponse<int> CreateUser(CreateUserCommand command)
        {
            return command.Validate(new CreateUserCommandValidator())
                .Check(new UserNameUnique(_userRepository) {UserName = command.UserName})
                .IfValid(() => _unitOfWorkFactory.Do(work =>
                {
                    var user = new User
                    {
                        Active = false,
                        Email = command.Email,
                        HashedPassword = command.Password,
                        UserName = command.UserName
                    };
                    _userRepository.Add(user);
                    return user.Id.AsOperationResponse();
                }));
        }

        public OperationResponse UpdateUser(UpdateUserCommand command)
        {
            return command.Validate(new UpdateUserCommandValidator())
                .IfValid(result => _unitOfWorkFactory.Do(work =>
                {
                    var user = _userRepository.GetById(command.Id);
                    user.Email = command.Email;
                    user.UserName = command.UserName;
                    _userRepository.Update(user);
                }));
        }

        public OperationResponse DeleteUser(Validated<int> id)
        {
            return id.Validate(new IdValidator())
                .IfValid(() => _unitOfWorkFactory.Do(work =>
                {
                    _userRepository.Delete(id);
                }));
        }
    }
}