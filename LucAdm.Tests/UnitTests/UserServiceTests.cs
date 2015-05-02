using FluentAssertions;
using NSubstitute;
using Xunit;

namespace LucAdm.Tests
{
    public class UserServiceTests : IClassFixture<ServiceFixture>
    {
        [NamedFact]
        [Trait("Category", "Unit")]
        public void CreateUser_Without_UserName_Should_Return_Validation_Error()
        {
            var response = UserService().CreateUser(Some.CreateUserCommand().With(userName: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }

        [NamedFact]
        [Trait("Category", "Unit")]
        public void CreateUser_Without_Password_Should_Return_Validation_Error()
        {
            var response = UserService().CreateUser(Some.CreateUserCommand().With(password: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.Password));
        }

        [NamedFact]
        [Trait("Category", "Unit")]
        public void CreateUser_With_Duplicated_UserName_Should_Return_Validation_Error()
        {
            var userService = UserService(Substitute.For<PersistenceContext>()
                .Where(x => x.Users.Returns(Some.User().With(userName: "existingName").AsList())));

            var response = userService.CreateUser(Some.CreateUserCommand().With(userName: "existingName"));

            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }

        private UserService UserService(PersistenceContext context = null)
        {
            return new UserService(new UserRepository(context), new UserQueryService(context), null);
        }
    }
}