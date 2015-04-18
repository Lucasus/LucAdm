using System.Configuration;
using OpenQA.Selenium;

namespace LucAdm.Tests
{
    public static class DriverExtensions
    {
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