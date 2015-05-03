namespace LucAdm
{
    public class UserNameUnique : IRule
    {
        private readonly UserQueryService _userQueryService;
        private string _userName;

        public UserNameUnique(UserQueryService userQueryService, string userName)
        {
            _userQueryService = userQueryService;
            _userName = userName;
        }

        public string ErrorMessage { get { return "User name must be unique"; } }

        public string Name { get { return PropertyName.Get((User x) => x.UserName); } }

        public bool Check()
        {
            return _userQueryService.CountByUserName(_userName) == 0;
        }
    }
}