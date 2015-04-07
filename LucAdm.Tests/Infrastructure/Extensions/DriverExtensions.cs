using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    public static class DriverExtensions
    {
        public static void GoToRelativeUrl(this INavigation navigation, string relativeUrl)
        {
            var port = Int32.Parse(ConfigurationManager.AppSettings.Get("Port"));

            if (!relativeUrl.StartsWith("/"))
            {
                relativeUrl = "/" + relativeUrl;
            }

            navigation.GoToUrl(String.Format("http://localhost:{0}{1}", port, relativeUrl));
        }
    }
}
