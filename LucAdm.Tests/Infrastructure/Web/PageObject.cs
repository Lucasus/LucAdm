using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucAdm.Tests
{
    public abstract class PageObject
    {
        public abstract string Url { get; }
        public IWebDriver WebDriver { get; set; }
    }
}
