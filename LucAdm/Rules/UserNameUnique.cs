namespace LucAdm
{
    public class UserNameUnique : Rule
    {
        private UserRepository userRepository;

        public string UserName { get; set; }

        public UserNameUnique(UserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.Name = GetPropertyName((User x) => x.UserName);
            this.Message = "User name must be unique";
        }

        public override bool Check()
        {
            return userRepository.GetByUserName(this.UserName) == null;
        }

    }
}