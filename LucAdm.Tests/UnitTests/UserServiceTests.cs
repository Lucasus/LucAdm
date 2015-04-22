﻿using FluentAssertions;
using NSubstitute;
using Xunit;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LucAdm.Tests
{
    public class UserServiceTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Validation_Error_When_Create_User_Without_UserName()
        {
            var response = new UserService(null, null).CreateUser(Some.CreateUserCommand().With(userName: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Validation_Error_When_Create_User_Without_Password()
        {
            var response = new UserService(null, null).CreateUser(Some.CreateUserCommand().With(password: ""));
            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.Password));
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Validation_Error_When_Create_User_With_Duplicated_UserName()
        {
            var userService = new UserService(new UserRepository(Substitute.For<PersistenceContext>()
                .Where(x => x.Users.Returns(Some.User().With(userName: "existingName").AsList()))), null);

            var response = userService.CreateUser(Some.CreateUserCommand().With(userName: "existingName"));

            response.ValidationResult.Errors.Should().ContainKey(PropertyName.Get((CreateUserCommand x) => x.UserName));
        }
    }
}