using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using LucAdm.DataGen;

namespace LucAdm.Tests
{
    public sealed class SeleniumFixture : IDisposable
    {
        private readonly SeleniumServer _seleniumServer;
        private readonly UsesDbFixture _usesDbFixture;
        private readonly WebServer _webServer;
        private readonly Browser _browser;

        public SeleniumFixture()
        {
            _usesDbFixture = new UsesDbFixture();
            new PersistenceContext().ResetDbState(EnvironmentEnum.Test);
            _webServer = new WebServer().Start();
            _seleniumServer = new SeleniumServer().Start();
            _browser = new Browser(new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory));
        }

        public Browser Browser { get { return _browser; } }

        public void Dispose()
        {
            _browser.Quit();
            _seleniumServer.Stop();
            _webServer.Stop();
            _usesDbFixture.Dispose();
        }
    }
};