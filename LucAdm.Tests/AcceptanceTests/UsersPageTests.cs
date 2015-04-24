using FluentAssertions;
using OpenQA.Selenium;
using Xunit;

namespace LucAdm.Tests
{
    public class UsersPageTests : IClassFixture<SeleniumFixture>
    {
        private readonly IWebDriver _driver;

        public UsersPageTests(SeleniumFixture seleniumFixture)
        {
            _driver = seleniumFixture.Driver;
        }

        [Fact]
        [Trait("Category", "Acceptance")]
        public void UsersPage_Should_Display_Header()
        {

            var usersPage = new UsersPage(_driver);

            _driver.Navigate().GoToRelativeUrl(usersPage.Url);

            usersPage.Header.Should().Contain("Luc");
        }
    }
}