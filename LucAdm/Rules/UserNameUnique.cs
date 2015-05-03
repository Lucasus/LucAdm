namespace LucAdm
{
    public class UserNameUnique : IRule
    {
        private readonly UserQueryService _userQueryService;

        public UserNameUnique(UserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        public string UserName { private get; set; }

        public string ErrorMessage
        {
            get { return "User name must be unique"; }
        }

        public string Name
        {
            get { return PropertyName.Get((User x) => x.UserName); }
        }

        public bool Check()
        {
            return _userQueryService.CountByUserName(UserName) == 0;
        }
    }
}