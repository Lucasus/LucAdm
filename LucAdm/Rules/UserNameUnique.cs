namespace LucAdm
{
    public class UserNameUnique : Rule
    {
        private readonly UserQueryService _userQueryService;

        public UserNameUnique(UserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
            Name = PropertyName.Get((User x) => x.UserName);
            Message = "User name must be unique";
        }

        public string UserName { private get; set; }

        public override bool Check()
        {
            return _userQueryService.CountByUserName(UserName) == 0;
        }
    }
}