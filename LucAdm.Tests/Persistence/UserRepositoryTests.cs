using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using LucAdm.DataGen;

namespace LucAdm.Tests
{
    [TestClass]
    public class UserRepositoryTests : DbTestBase
    {
        // https://github.com/scott-xu/EntityFramework.Testing
        [TestMethod]
        public void User_Should_Be_Saved_Correctly()
        {
            // arrange
            var userRepository = new UserRepository(dbContext);

            var newUser = new User()
            {
                Email = "user@user.com",
                UserName = "newUser",
                HashedPassword = "hashedPassword",
            };

            // act
            new UnitOfWork(dbContext).Do((work) => 
            { 
                userRepository.Add(newUser); 
            });

            // assert
            userRepository.GetById(newUser.Id).ShouldBeEquivalentTo(newUser);
        }
    }
}
