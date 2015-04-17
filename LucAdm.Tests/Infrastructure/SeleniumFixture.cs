using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LucAdm.Tests
{
    public sealed class SeleniumFixture : IDisposable
    {
        private UsesDBFixture usesDbFixture;
        private SeleniumServer seleniumServer;
        private WebsiteServer webServer;
        private IWebDriver driver;

        public IWebDriver Driver { get { return driver; } }

        public SeleniumFixture()
        {
            usesDbFixture = new UsesDBFixture();
            webServer = new WebsiteServer().Start();
            seleniumServer = new SeleniumServer().Start();
            driver = new ChromeDriver(@"C:\Core\Selenium");
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
            seleniumServer.Stop();
            webServer.Stop();
            usesDbFixture.Dispose();
        }
    }
}
