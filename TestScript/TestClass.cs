using FBDesktop.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace FBDesktop
{
    public class Tests
    {
        public const string AppiumURI = "http://127.0.0.1:4723/";
        public const string FacebookID = "Facebook.FacebookBeta_8xx8rvfyw5nnt!App";
        public WindowsDriver<WindowsElement> Driver;

        [SetUp]
        public void SetUp()
        {
            //Launch Facebook Desktop
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", FacebookID);
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("platformName", "windows");
            Driver = new WindowsDriver<WindowsElement>(new Uri(AppiumURI), options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Test]
        public void VerifySuccessulSignin()
        {
            LoginPage lp = new LoginPage(Driver);
            lp.EnterUsername("testuser");
            lp.EnterPassword("testpassword");
            lp.ClickLogIn();
            Assert.IsTrue(lp.IsLoginSuccessful());
        }

        [Test]
        public void VerifyStatusPost()
        {
            NewsFeedPage nfp = new NewsFeedPage(Driver);
            nfp.OpenComposer();
            nfp.WriteStatus("This is an automated test status");
            nfp.ClickPost();
        }

        [Test]
        public void VerifyCheckingIntoLocation()
        {
            NewsFeedPage nfp = new NewsFeedPage(Driver);
            nfp.OpenComposer();
            nfp.ClickCheckIn();
            nfp.TypeLocation("Facebook HQ");
            nfp.ClickPost();
        }

        [Test]
        public void VerifySearch()
        {
            NewsFeedPage nfp = new NewsFeedPage(Driver);
            nfp.ClickSearchBar();
            nfp.SearchInSearchBar("Mark Zuckerberg");
            nfp.PressEnter();
        }

        [Test]
        public void VerifyClickingAllBookmarkOptions()
        {
            NewsFeedPage nfp = new NewsFeedPage(Driver);
            nfp.ClickAllBookmarkOptions();
            String LastTab = Driver.FindElementsByXPath("//Pane/Button")[30].Text;
            Assert.AreEqual(LastTab, "Saved");
        }

        [Test]
        public void VerifyCreatingEvent()
        {
            NewsFeedPage nfp = new NewsFeedPage(Driver);
            nfp.ClickEventsTab();
            nfp.ClickPrivateEvent();
            nfp.EnterEventTitle("Test Event");
            nfp.EnterEventInformation("This is a test event");
            nfp.ClickCreate();
        }

        [Test]
        public void VerifyProfileOpens()
        {
            ProfilePage pp = new ProfilePage(Driver);
            pp.NavigateToProfile();
            Assert.IsTrue(pp.DidProfileLoad());
        }

        public void VerifyAddingBio()
        {
            ProfilePage pp = new ProfilePage(Driver);
            try
            {
                pp.ClickAddBio();
                pp.EnterBio("This is a test account");
                pp.ClickSave();
            }
            catch (Exception e)
            {
                Console.WriteLine("Bio already exists, skipping test");
            }
        }

        [Test]
        public void VerifyActivityLogOpened()
        {
            ProfilePage pp = new ProfilePage(Driver);
            pp.ClickActivityLog();
            Assert.IsTrue(pp.DidActivityLogOpen());
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
