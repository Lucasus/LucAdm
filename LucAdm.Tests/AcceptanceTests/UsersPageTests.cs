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

            usersPage.UsersList.Should().Contain(item => item.Contains(Users.GandalfTheAdmin.UserName) && item.Contains(Users.GandalfTheAdmin.Email));
        }

        [Fact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_ShouldRemove_User()
        {
            var usersPage = _browser.Load(new UsersPage());

            usersPage.ClickRemoveFor(Users.Frodo.UserName);
            usersPage.AcceptRemove();

            usersPage.UsersList.Should().NotContain(item => item.Contains(Users.Frodo.UserName));
        }

    }
}