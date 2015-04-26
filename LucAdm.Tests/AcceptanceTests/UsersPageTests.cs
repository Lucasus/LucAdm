using FluentAssertions;
using LucAdm.DataGen;
using System.Linq;
using OpenQA.Selenium;
using Xunit;
using System.ComponentModel;

namespace LucAdm.Tests
{
    public class UsersPageTests : IClassFixture<SeleniumFixture>
    {
        private readonly Browser _browser;

        public UsersPageTests(SeleniumFixture seleniumFixture)
        {
            _browser = seleniumFixture.Browser;
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_ShouldDisplay_Header()
        {
            new PersistenceContext().ResetDbState(EnvironmentEnum.Test);
            var usersPage = _browser.Load(new UsersPage());

            usersPage.Header.Should().Contain("Luc");
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_ShouldDisplay_ListOfUsers()
        {
            new PersistenceContext().ResetDbState(EnvironmentEnum.Test);
            var usersPage = _browser.Load(new UsersPage());

            usersPage.GetUsersList().Should().NotBeEmpty();
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_Can_Search_By_UserName()
        {
            new PersistenceContext().ResetDbState(EnvironmentEnum.Test);
            var usersPage = _browser.Load(new UsersPage());

            usersPage.GetUsersList();
            usersPage.SearchFor(Users.Frodo.UserName);

            var users = usersPage.GetUsersList(expectedCount: 1);
            users.Should().HaveCount(1);
            users.Should().Contain(item => item.Contains(Users.Frodo.UserName) && item.Contains(Users.Frodo.Email));
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_Can_Remove_User()
        {
            new PersistenceContext().ResetDbState(EnvironmentEnum.Test);
            var usersPage = _browser.Load(new UsersPage());

            usersPage.SearchFor(Users.Frodo.UserName);
            usersPage.ClickRemoveFor(Users.Frodo.UserName);
            usersPage.AcceptRemove();

            usersPage.GetUsersList(expectedCount: 0).Should().BeEmpty();
        }
    }
}