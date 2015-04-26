using FluentAssertions;
using LucAdm.DataGen;
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

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_ShouldDisplay_Header()
        {
            var usersPage = preparePage();

            usersPage.Header.Should().Contain("Luc");
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_ShouldDisplay_ListOfUsers()
        {
            var usersPage = preparePage();

            usersPage.GetUsersList().Should().NotBeEmpty();
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_Can_Search_By_UserName()
        {
            var usersPage = preparePage();

            usersPage.SearchFor(Users.Frodo.UserName);
            var users = usersPage.GetUsersList(expectedCount: 1);

            users.Should().HaveCount(1);
            users.Should().Contain(item => item.Contains(Users.Frodo.UserName) && item.Contains(Users.Frodo.Email));
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_Can_Remove_User()
        {
            var usersPage = preparePage();

            usersPage.SearchFor(Users.Frodo.UserName);
            usersPage.ClickRemoveFor(Users.Frodo.UserName);
            usersPage.AcceptRemove();

            usersPage.GetUsersList(expectedCount: 0).Should().BeEmpty();
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_Can_Add_User()
        {
            var newUserName = "BilboBaggins";
            var newUserEmail = "bilbo@bilbo.com";
            var usersPage = preparePage();

            usersPage.ClickAddUser();
            usersPage.FillNewUserForm(newUserName, newUserEmail, "somePassword");
            usersPage.ModalClickOK();
            usersPage.SearchFor(newUserName);
            var users = usersPage.GetUsersList(expectedCount: 1);

            users.Should().HaveCount(1);
            users.Should().Contain(item => item.Contains(newUserName) && item.Contains(newUserEmail));
        }


        private UsersPage preparePage()
        {
            new PersistenceContext().ResetDbState(EnvironmentEnum.Test);
            var usersPage = _browser.Load(new UsersPage());
            usersPage.GetUsersList(timeout: 10);
            return usersPage;
        }
    }
}