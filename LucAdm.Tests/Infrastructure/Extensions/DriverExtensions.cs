using System.Configuration;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using System;
using OpenQA.Selenium.Support.UI;

namespace LucAdm.Tests
{
    public static class DriverExtensions
    {
        public static IReadOnlyCollection<IWebElement> WaitForCss(this IWebDriver driver, string cssSelector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x =>
            {
                return driver.Css(cssSelector).Count > 0;
            });
            return driver.Css(cssSelector);
        }

        public static IReadOnlyCollection<IWebElement> Css(this IWebDriver driver, string cssSelector)
        {
            return driver.FindElements(By.CssSelector(cssSelector));
        }

        public static void GoToRelativeUrl(this INavigation navigation, string relativeUrl)
        {
            var port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));

            if (!relativeUrl.StartsWith("/"))
            {
                relativeUrl = "/" + relativeUrl;
            }

            navigation.GoToUrl(string.Format("http://localhost:{0}{1}", port, relativeUrl));
        }
    }
}