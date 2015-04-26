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

        public string Header { get { return Driver.ListByCss("header").FirstOrDefault().Text; } }

        public IList<string> UsersList 
        { 
            get 
            {
                return getUserElements().Select(x => x.Content()).ToList(); 
            } 
        }     

        public void ClickRemoveFor(string userName)
        {
            var userElements = getUserElements();
            var userToDelete = userElements.First(x => x.Text.Contains(userName));
            var btnRemove = userToDelete.ElementByCss(".cmdDelete");
            btnRemove.Click();
        }

        public void AcceptRemove()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        private IList<IWebElement> getUserElements()
        {
            return Driver.WaitForListByCss(".user-item").ToList();
        }
    } 
}