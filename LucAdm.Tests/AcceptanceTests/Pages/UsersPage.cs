using OpenQA.Selenium;

namespace LucAdm.Tests
{
    public class UsersPage
    {
        private IWebDriver driver;

        public UsersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Url { get { return "/"; } }

        public string Header
        {
            get
            {
                var header = driver.FindElement(By.CssSelector("header"));
                return header.Text;
            }
        }
    }
}
