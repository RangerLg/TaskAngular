using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Xunit;

namespace TaskAngular.Tests
{
    public class UnitTest1 : BaseTest
    {
        [Fact]
        void AddItem()
        {
            AddTestUser();
            Thread.Sleep(1000);
            Driver.Navigate().GoToUrl(Url);
            LoginAndRegisterForm();
            var element = Driver.FindElement(
                By.XPath(LoginButtonXPath));
            element.Click();
            element = Driver.FindElement(By.XPath(AddCollectionButtonXPath));
            element.Click();
                SetAddCollectionValue();
            element = Driver.FindElement(
                By.XPath(AddCollectionFormButtonXPath));
            element.Click();
            try
            {
                IAlert alert = Wait.Until(ExpectedConditions.AlertIsPresent());
                alert.Accept();
            }
            catch
            {
                // ignored
            }

            element = Driver.FindElement(By.XPath(MyCollectionButtonXpath));
            element.Click();
            element = Driver.FindElement(By.XPath(CollectionMoreXpath));
            element.Click();
            element = Driver.FindElement(By.XPath(AddItemButtonXPath));
            element.Click();
            SetAddItemModel();
            element = Driver.FindElement(By.XPath(AddItemFormButtonXPath));
            element.Click();
            try
            {
                IAlert alert = Wait.Until(ExpectedConditions.AlertIsPresent());
                alert.Accept();
            }
            catch
            {
                // ignored
            }
            Assert.NotNull(FindTestItem());
            DeleteTestItem();
            DeleteTestCollection();
            DeleteTestUser();
            Driver.Close();
        }
        [Fact]
        void AddCollectionUnauthorized()
        {
            Driver.Navigate().GoToUrl(Url);
            var element = Driver.FindElement(By.XPath(AddCollectionButtonXPath));
            element.Click();
            SetAddCollectionValue();
            element = Driver.FindElement(
                By.XPath(AddCollectionFormButtonXPath));
            element.Click();
            try
            {
                IAlert alert = Wait.Until(ExpectedConditions.AlertIsPresent());
                alert.Accept();
            }
            catch
            {
                // ignored
            }
            Assert.Null(FindTestCollection());
            Driver.Close();
        }
        [Fact]
        void AddCollection()
        {
            AddTestUser();
            Driver.Navigate().GoToUrl(Url);
            LoginAndRegisterForm();
            var element = Driver.FindElement(By.XPath(LoginButtonXPath));
            element.Click();
            element = Driver.FindElement(By.XPath(AddCollectionButtonXPath));
            element.Click();
            SetAddCollectionValue();
            element = Driver.FindElement(
                By.XPath(AddCollectionFormButtonXPath));
            element.Click();
            Assert.NotNull(FindTestCollection());
            DeleteTestCollection();
            DeleteTestUser();
            Driver.Close();
        }
        [Fact]
        void Login()
        {
            AddTestUser();
            Thread.Sleep(1000);
            Driver.Navigate().GoToUrl(Url);
            LoginAndRegisterForm();
            var element = Driver.FindElement(
                By.XPath(LoginButtonXPath));
            element.Click();
            Assert.True(true);
            DeleteTestUser();
            Driver.Close();
        }
        [Fact]
        void RegisterNewUser()
        { 
            Driver.Navigate().GoToUrl(Url);
            LoginAndRegisterForm();
            var element = Driver.FindElement(
                By.XPath(RegisterButtonXPath));
            element.Click();
            IAlert alert = Wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            Assert.NotNull(FindTestUser());
            DeleteTestUser();
            Driver.Close();
        }

        [Fact]
        void RegisterNewUserWhichAlreadyRegistered()
        {
            AddTestUser();
            Driver.Navigate().GoToUrl(Url);
            LoginAndRegisterForm();
            var element = Driver.FindElement(
                By.XPath(RegisterButtonXPath));
            element.Click();
            IAlert alert = Wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            Assert.NotNull(FindTestUser());
            DeleteTestUser();
            Driver.Close();
        }

        void LoginAndRegisterForm()
        {
            IWebElement element = Driver.FindElement(By.XPath(LoginFormXPath));
            element.SendKeys(Email);
            element = Driver.FindElement(
                By.XPath(PasswordFormXPath));
            element.SendKeys(Password);
        }

        void SetAddCollectionValue()
        {
            var element = Driver.FindElement(
                By.XPath(CollectionNameFormXPath));
            element.SendKeys(CollectionName);
            
            element = Driver.FindElement(
                By.XPath(CollectionTopicFormXPath));
            element.SendKeys(CollectionTopic);
            element = Driver.FindElement(
                By.XPath(CollectionDescFormXPath));
            element.SendKeys(CollectionDesc);
        }

        void SetAddItemModel()
        {
            var element = Driver.FindElement(By.XPath(AddItemNameFormXPath));
            element.SendKeys(ItemName);
        }
    }
}