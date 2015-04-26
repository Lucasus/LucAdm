using FluentAssertions;
using LucAdm.DataGen;
using System.Linq;
using OpenQA.Selenium;
using Xunit;

namespace LucAdm.Tests
{
    public class UsersPageTests : IClassFixture<SeleniumFixture>
    {
        private readonly Browser _browser;

        public UsersPageTests(SeleniumFixture seleniumFixture)
        {
            _browser = seleniumFixture.Browser;
        }

        [Fact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_ShouldDisplay_Header()
        {
            var usersPage = _browser.Load(new UsersPage());
            usersPage.Header.Should().Contain("Luc");
        }

        [Fact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_ShouldDisplay_ListOfUsers()
        {
            var usersPage = _browser.Load(new UsersPage());
            usersPage.UsersList.Should().Contain(item => item.Contains(Users.Admin.UserName) && item.Contains(Users.Admin.Email));
        }
    }
}