using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace LucAdm.Tests
{
    public class UsersPage : PageObject
    {
        public override string Url { get { return "/"; } }

        public string Header { get { return Driver.ListByCss("header").FirstOrDefault().Text; } }

        public IList<string> GetUsersList(int? expectedCount = null, double timeout = 5)
        {
            return getUserElements(expectedCount, timeout).Select(x => x.Content()).ToList();
        }

        public void ClickRemoveFor(string userName)
        {
            var userToDelete = getUserElements().First(x => x.Text.Contains(userName));
            userToDelete.ElementFor(".cmdDelete").Click();
        }

        public void SearchFor(string searchTerm)
        {
            Driver.ElementFor("input[ng-model=\"users.searchTerm\"").SendKeys(searchTerm);
            Driver.ElementFor("button[ng-click=\"search()\"").Click();
        }

        public void AcceptRemove()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        public void ClickAddUser()
        {
            Driver.ElementFor("button[ng-click=\"openModal('')\"").Click();
        }

        public void FillNewUserForm(string userName, string email, string password)
        {
            Driver.WaitElementFor(userNameInputSelector()).SendKeys(userName);
            Driver.ElementFor("input[ng-model=\"user.email\"").SendKeys(email);
            Driver.ElementFor("input[ng-model=\"user.password\"").SendKeys(password);
        }

        public void ModalClickOK()
        {
            Driver.ElementFor("button[ng-click=\"save(user)\"").Click();
            Driver.WaitUntilHidden(userNameInputSelector());
        }

        private string userNameInputSelector()
        {
            return "input[ng-model=\"user.userName\"";
        }

        private IList<IWebElement> getUserElements(int? expectedCount = null, double timeout = 5)
        {
            return Driver.WaitListFor(".user-item", expectedCount, timeout).ToList();
        }
    }
}