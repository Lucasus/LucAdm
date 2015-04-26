using FluentAssertions;
using Xunit;

namespace LucAdm.Tests
{
    public class UserRepositoryTests : IClassFixture<UsesDbFixture>
    {
        // https://github.com/scott-xu/EntityFramework.Testing
        [NamedFact]
        [Trait("Category", "Integration")]
        public void User_Should_Be_Saved_Correctly()
        {
            var context = new PersistenceContext().ResetDbState();
            var userRepository = new UserRepository(context);
            User newUser = Some.User();

            new UnitOfWork(context).Do(work => { userRepository.Add(newUser); });

            userRepository.GetById(newUser.Id).ShouldBeEquivalentTo(newUser);
        }
    }
}