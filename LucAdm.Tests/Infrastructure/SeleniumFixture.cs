using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data.Entity.Migrations;

namespace LucAdm.Tests
{
    public class SeleniumFixture : IDisposable
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
            seleniumServer.Stop();
            webServer.Stop();
            usesDbFixture.Dispose();
        }
    }
}
