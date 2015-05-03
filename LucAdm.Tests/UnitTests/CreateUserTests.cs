using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace LucAdm.Tests
{
    public class CreateUserTests : IClassFixture<ServiceFixture>
    {
        [NamedFact, Trait("Category", "Unit")]
        public void CreateUser_With_Correct_Command_Should_Create_User()
        {
            var context = Some.Context().With(new List<User>()).Build();
            var userRepository = Substitute.For<Repository<User>>(context);

            var response = Some.UserService(context, userRepository).CreateUser(Some.CreateUserCommand().With(password: "pass", rePassword: "pass"));

            response.ValidationResult.Errors.Should().BeEmpty();
            userRepository.Received(1).Add(Arg.Any<User>());
        }

        [NamedFact, Trait("Category", "Unit")]
        public void CreateUser_Without_UserName_Should_Return_Validation_Error()
        {
            var response = Some.UserService().CreateUser(Some.CreateUserCommand().With(userName: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }

        [NamedFact, Trait("Category", "Unit")]
        public void CreateUser_Without_Password_Should_Return_Validation_Error()
        {
            var response = Some.UserService().CreateUser(Some.CreateUserCommand().With(password: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.Password));
        }

        [NamedFact, Trait("Category", "Unit")]
        public void CreateUser_With_Incorrectly_Repeated_Password_Should_Return_Validation_Error()
        {
            var response = Some.UserService().CreateUser(Some.CreateUserCommand().With(password: "pass", rePassword: "rePass"));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.RepeatedPassword));
        }

        [NamedFact, Trait("Category", "Unit")]
        public void CreateUser_With_Duplicated_UserName_Should_Return_Validation_Error()
        {
            var users = Some.User().With(userName: "existingName").ToList();           
            var userService = Some.UserService(Some.Context().With(users));

            var response = userService.CreateUser(Some.CreateUserCommand().With(userName: "existingName"));

            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }
    }
}