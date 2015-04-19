using System;

namespace LucAdm
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UnitOfWorkFactoy _unitOfWorkFactory;

        public UserService(UserRepository userRepository, UnitOfWorkFactoy unitOfWorkFactory)
        {
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public OperationResponse<int> CreateUser(CreateUserCommand command)
        {
            return command.Validate(new CreateUserCommandValidator())
                .And(new UserNameUnique(_userRepository) {UserName = command.UserName})
                .IfValid(() =>
                {
                    var user = new User()
                    {
                        Active = false,
                        Email = command.Email,
                        HashedPassword = command.Password,
                        UserName = command.UserName
                    };

                    Do(work =>
                    {
                        _userRepository.Add(user);
                    });

                    return new OperationResponse<int>(user.Id);
                });
        }

        private void Do(Action<UnitOfWork> work)
        {
            _unitOfWorkFactory.Create().Do(work);
        }
    }
}