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
        public void Should_Display_Users_Page()
        {
            var usersPage = new UsersPage(_driver);
            _driver.Navigate().GoToRelativeUrl(usersPage.Url);
            usersPage.Header.Should().Contain("Luc");
        }
    }
}