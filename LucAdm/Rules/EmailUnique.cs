namespace LucAdm
{
    public class EmailUnique : Rule
    {
        private readonly UserQueryService _userQueryService;

        public EmailUnique(UserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
            Name = PropertyName.Get((User x) => x.Email);
            Message = "Email must be unique";
        }

        public string Email { private get; set; }

        public override bool Check()
        {
            return _userQueryService.CountByEmail(Email) == 0;
        }
    }
}