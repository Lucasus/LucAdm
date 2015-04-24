using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace LucAdm.Tests
{
    public sealed class SeleniumFixture : IDisposable
    {
        private readonly SeleniumServer _seleniumServer;
        private readonly UsesDbFixture _usesDbFixture;
        private readonly WebsiteServer _webServer;

        public SeleniumFixture()
        {
            _usesDbFixture = new UsesDbFixture();
            _webServer = new WebsiteServer().Start();
            _seleniumServer = new SeleniumServer().Start();
            var chromeDriverFolder = AppDomain.CurrentDomain.BaseDirectory;
            Driver = new ChromeDriver(chromeDriverFolder);
        }

        public IWebDriver Driver { get; private set; }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
            _seleniumServer.Stop();
            _webServer.Stop();
            _usesDbFixture.Dispose();
        }
    }
}