﻿using FluentAssertions;
using Xunit;

namespace LucAdm.Tests
{
    public class UserRepositoryTests : IClassFixture<UsesDbFixture>
    {
        // https://github.com/scott-xu/EntityFramework.Testing
        [Fact]
        [Trait("Category", "Integration")]
        public void User_Should_Be_Saved_Correctly()
        {
            // arrange
            var context = new PersistenceContext().ResetDbState();
            var userRepository = new UserRepository(context);

            var newUser = new User
            {
                Email = "user@user.com",
                UserName = "newUser",
                HashedPassword = "hashedPassword"
            };

            // act
            new UnitOfWork(context).Do(work => { userRepository.Add(newUser); });

            // assert
            userRepository.GetById(newUser.Id).ShouldBeEquivalentTo(newUser);
        }
    }
}