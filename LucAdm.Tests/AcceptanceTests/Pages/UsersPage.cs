using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LucAdm.Tests
{
    public class UsersPage : PageObject
    {
        public override string Url { get { return "/"; } } 

        public string Header { get { return WebDriver.Css("header").FirstOrDefault().Text; } }

        public IList<string> UsersList { get { return WebDriver.WaitForCss(".user-item").Select(x => x.Content()).ToList(); } }     
    } 
}