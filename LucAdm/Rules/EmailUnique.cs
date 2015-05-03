namespace LucAdm
{
    public class EmailUnique : IRule
    {
        private readonly UserQueryService _userQueryService;

        public EmailUnique(UserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        public string Email { private get; set; }

        public string ErrorMessage
        {
            get { return "Email must be unique"; }
        }

        public string Name
        {
            get { return PropertyName.Get((User x) => x.Email); }
        }

        public bool Check()
        {
            return _userQueryService.CountByEmail(Email) == 0;
        }
    }
}