﻿namespace LucAdm
{
    public class UserService
    {
        private readonly UserQueryService _userQueryService;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private readonly Repository<User> _userRepository;

        public UserService(Repository<User> userRepository, UserQueryService userQueryService, UnitOfWorkFactory unitOfWorkFactory)
        {
            _userQueryService = userQueryService;
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
        }

        public OperationResponse<int> CreateUser(CreateUserCommand command)
        {
            return command.Validate(new CreateUserCommandValidator())
                .Check(new UserNameUnique(_userQueryService) { UserName = command.UserName })
                .Check(new EmailUnique(_userQueryService) { Email = command.Email })
                .IfValid(() => _unitOfWorkFactory.Do(work =>
                {
                    var user = new User
                    {
                        Active = false,
                        Email = command.Email,
                        HashedPassword = new HashProvider().GetPasswordHash(command.Password),
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