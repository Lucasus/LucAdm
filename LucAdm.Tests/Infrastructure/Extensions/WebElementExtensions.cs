using OpenQA.Selenium;

namespace LucAdm.Tests
{
    public static class WebElementExtensions
    {
        public static string Content(this IWebElement element)
        {
            if (element == null)
            {
                return null;
            }
            return element.GetAttribute("innerHTML");
        }
    }
}