using FluentAssertions;
using NSubstitute;
using Xunit;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LucAdm.Tests
{
    public class UserServiceTests
    {
        [NamedFact]
        [Trait("Category", "Unit")]
        public void CreateUser_Without_UserName_Should_Return_Validation_Error()
        {
            var response = new UserService(null, null).CreateUser(Some.CreateUserCommand().With(userName: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }

        [NamedFact]
        [Trait("Category", "Unit")]
        public void CreateUser_Without_Password_Should_Return_Validation_Error()
        {
            var response = new UserService(null, null).CreateUser(Some.CreateUserCommand().With(password: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.Password));
        }

        [NamedFact]
        [Trait("Category", "Unit")]
        public void CreateUser_With_Duplicated_UserName_Should_Return_Validation_Error()
        {
            var userService = new UserService(new UserRepository(Substitute.For<PersistenceContext>()
                .Where(x => x.Users.Returns(Some.User().With(userName: "existingName").AsList()))), null);

            var response = userService.CreateUser(Some.CreateUserCommand().With(userName: "existingName"));

            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }
    }

}