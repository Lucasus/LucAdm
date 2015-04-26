using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace LucAdm.Tests
{
    public class Browser
    {
        private IWebDriver _webDriver;

        public Browser(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public T Load<T>(T page)
            where T: PageObject
        {
            page.Driver = _webDriver;
            _webDriver.Navigate().GoToRelativeUrl(page.Url);
            return page;
        }

        public void Quit()
        {
            _webDriver.Quit();
            _webDriver.Dispose();
        }
    }
}