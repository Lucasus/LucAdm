namespace LucAdm.Tests
{
    public class UserBuilder : ObjectBuilder<User>
    {
        public UserBuilder Create()
        {
            Instance = new User
            {
                UserName = "userName",
                Email = "email@email.com",
                Active = true
            };
            return this;
        }

        public UserBuilder With(string userName = null, string email = null)
        {
            Instance.UserName = userName ?? Instance.UserName;
            Instance.Email = email ?? Instance.Email;
            return this;
        }
    }
}