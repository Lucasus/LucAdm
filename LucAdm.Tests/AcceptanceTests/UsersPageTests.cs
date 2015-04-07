using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Configuration;
using Xunit;

namespace LucAdm.Tests
{
    public class UsersPageTests : IClassFixture<SeleniumFixture>
    {
        private IWebDriver driver;

        public UsersPageTests(SeleniumFixture seleniumFixture)
        {
            this.driver = seleniumFixture.Driver;
        }

        [Fact]
        [Trait("Category", "Acceptance")]
        public void Should_Display_Users_Page()
        {
            var usersPage = new UsersPage(driver);
            driver.Navigate().GoToRelativeUrl(usersPage.Url);
            usersPage.Header.Should().Contain("Luc");
        }
    }
}
