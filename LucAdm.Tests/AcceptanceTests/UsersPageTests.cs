﻿using FluentAssertions;
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

            usersPage.UsersList.Should().Contain(item => item.Contains(Users.Frodo.UserName) && item.Contains(Users.Frodo.Email));
        }

        [NamedFact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_Should_Be_Possible_To_Remove_User()
        {
            new PersistenceContext().ResetDbState(EnvironmentEnum.Test);
            var usersPage = _browser.Load(new UsersPage());

            usersPage.ClickRemoveFor(Users.Frodo.UserName);
            usersPage.AcceptRemove();

            usersPage.UsersList.Should().NotContain(item => item.Contains(Users.Frodo.UserName));
        }

    }
}