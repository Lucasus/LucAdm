using FluentAssertions;
using NSubstitute;
using Xunit;

namespace LucAdm.Tests
{
    public class UserServiceTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Should_Not_Be_Possible_To_Create_User_Without_UserName()
        {
            // arrange
            var userService = new UserService(null);

            // act
            var response = userService.CreateUser(new CreateUserCommand()
            {
                AcceptedTermsOfUse = true,
                Email = "email@email.com",
                Password = "somePassword",
                RepeatedPassword = "somePassword",
                UserName = "",
            });

            // assert
            response.ValidationResult.Errors.Should().ContainKey("UserName");
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_Not_Be_Possible_To_Create_User_With_Duplicated_UserName()
        {
            // arrange
            var duplicatedUserName = "existingName";
            var userRepository = Substitute.For<UserRepository>((PersistenceContext)null);
            userRepository.GetByUserName(duplicatedUserName).Returns(new User() { Id = 1, UserName = duplicatedUserName });
            var userService = new UserService(userRepository);

            // act
            var response = userService.CreateUser(new CreateUserCommand()
            {
                AcceptedTermsOfUse = true,
                Email = "email@email.com",
                Password = "somePassword",
                RepeatedPassword = "somePassword",
                UserName = duplicatedUserName
            });

            // assert
            response.ValidationResult.Errors.Should().ContainKey("UserName");
        }
    }
}
