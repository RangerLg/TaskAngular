using System;
using System.Linq;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TaskAngular.Auth.api.Models;
using TaskAngular.Resource.api.Models;
using TaskAngular.Tests.DbContext;
using Collection = TaskAngular.Resource.api.Models.Collection;

namespace TaskAngular.Tests
{
    public class BaseTest : Selectors
    {
        protected const string Email = "dvasjsaldjasljdlasjdjasjldj@saljdkjasldjaksd.com";
        protected const string Password = "1234";
        protected const string CollectionName = "asdsadas dsadasdsadasdasdsadasdasd";
        protected const string CollectionDesc = "asd";
        protected const string CollectionTopic = "asd";
        protected const string ItemName = "asd";
        protected const string Url = @"http://localhost:4200/";
        protected static IWebDriver Driver;
        protected static WebDriverWait Wait;

        protected BaseTest()
        {
            Driver = new ChromeDriver("D:/Selenium");
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1));
        }

        protected void DeleteTestUser()
        {
            using var appDbContex = new AppDbContex();
            var account = appDbContex.Accounts.FirstOrDefault(d => d.Email == Email);
            if (account != null)
            {
                appDbContex.Accounts.Remove(account);
                appDbContex.SaveChanges();
            }
        }

        protected void DeleteTestCollection()
        {
            using var appDbContex = new AppDbContex();
            var account = appDbContex.Accounts.FirstOrDefault(d => d.Email == Email);
            var collections = appDbContex.Collections.Where(d => d.UserName == account.Id.ToString());
            appDbContex.Collections.RemoveRange(collections);
            if (account != null)
            {
                appDbContex.Accounts.Remove(account);
                appDbContex.SaveChanges();
            }
        }


        protected Account FindTestUser()
        {
            using var appDbContex = new AppDbContex();
            var account = appDbContex.Accounts.First(d => d.Email == Email);
            return account;
        }

        protected void AddTestUser()
        {
            DeleteTestUser();
            using var appDbContex = new AppDbContex();
            appDbContex.Accounts.Add(new Account
                {Id = Guid.NewGuid(), Email = Email, Password = Password, Roles = "User"});
            appDbContex.SaveChanges();
        }

        protected Collection FindTestCollection()
        {
            using var appDbContex = new AppDbContex();
            var account = appDbContex.Accounts.FirstOrDefault(d => d.Email == Email);
            if (account != null)
            {
                return appDbContex.Collections.First(d => d.UserName == account.Id.ToString());
            }

            return null;
        }

        protected Item FindTestItem()
        {
            using var appDbContex = new AppDbContex();
            var account = appDbContex.Accounts.FirstOrDefault(d => d.Email == Email);
            var collection = appDbContex.Collections.FirstOrDefault(d => d.UserName == account.Id.ToString());
            if (account != null&&collection!=null)
            {
                return appDbContex.Items.First(d => d.NameItem == ItemName);
            }

            return null;
        }

        protected void DeleteTestItem()
        {
            using var appDbContex = new AppDbContex();
            var account = appDbContex.Accounts.FirstOrDefault(d => d.Email == Email);
            var collection = appDbContex.Collections.FirstOrDefault(d => d.UserName == account.Id.ToString());
            if (account != null&&collection!=null)
            {
                var Item =  appDbContex.Items.First(d => d.NameItem == ItemName&&d.IdCollection==collection.ID);
                appDbContex.Items.Remove(Item);
                appDbContex.SaveChanges();
            }
        }
    }
}