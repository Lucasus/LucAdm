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

        public IList<string> GetUsersList(bool shouldBeEmpty = false)
        { 
            return getUserElements(shouldBeEmpty).Select(x => x.Content()).ToList(); 
        }     

        public void ClickRemoveFor(string userName)
        {
            var userElements = getUserElements();
            var userToDelete = userElements.First(x => x.Text.Contains(userName));
            var btnRemove = userToDelete.ElementByCss(".cmdDelete");
            btnRemove.Click();
        }

        public void SearchFor(string searchTerm)
        {
            var searchBox = Driver.ElementByCss("input[ng-model=\"users.searchTerm\"");
            searchBox.SendKeys(searchTerm);

            var searchButton = Driver.ElementByCss("button[ng-click=\"search()\"");
            searchButton.Click();
        }

        public void AcceptRemove()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        private IList<IWebElement> getUserElements(bool shouldBeEmpty = false)
        {
            return Driver.WaitForListByCss(".user-item", shouldBeEmpty).ToList();
        }
    } 
}