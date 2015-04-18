using OpenQA.Selenium;

namespace LucAdm.Tests
{
    public class UsersPage
    {
        private readonly IWebDriver _driver;

        public UsersPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Url
        {
            get { return "/"; }
        }

        public string Header
        {
            get
            {
                var header = _driver.FindElement(By.CssSelector("header"));
                return header.Text;
            }
        }
    }
}