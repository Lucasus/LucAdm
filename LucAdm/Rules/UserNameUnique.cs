namespace LucAdm
{
    public class UserNameUnique : Rule
    {
        private readonly UserRepository _userRepository;

        public UserNameUnique(UserRepository userRepository)
        {
            _userRepository = userRepository;
            Name = PropertyName.Get((User x) => x.UserName);
            Message = "User name must be unique";
        }

        public string UserName { private get; set; }

        public override bool Check()
        {
            return _userRepository.GetByUserName(UserName) == null;
        }
    }
}