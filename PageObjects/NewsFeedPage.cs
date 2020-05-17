using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;

namespace FBDesktop.Pages
{
    class NewsFeedPage
    {
        WindowsDriver<WindowsElement> Driver;

        public NewsFeedPage(WindowsDriver<WindowsElement> Driver)
        {
            this.Driver = Driver; 
        }

        public void ClickAllBookmarkOptions()
        {
            for (int i = 14; i < 30; i++)
            {
                WindowsElement BookmarkTabs = Driver.FindElementsByXPath("//Pane/Button")[i];
                BookmarkTabs.Click();
            }
        }

        public void OpenComposer()
        {
            Driver.FindElementByName("Whats on your mind?").Click();
        }

        public void WriteStatus(String status)
        {
            Actions WriteStatus = new Actions(Driver);
            WriteStatus.SendKeys(status).Build().Perform();
        }

        public void ClickPost()
        {
            Driver.FindElementByName("Post").Click();
        }

        public void ClickCheckIn()
        {
            Driver.FindElementByName("Add more to your post").Click();
            Driver.FindElementByName("Check In").Click();
        }

        public void TypeLocation(String location)
        {
            Driver.FindElementByName("Search for places").SendKeys(location);
            Actions SelectFirstResult = new Actions(Driver);
            SelectFirstResult.MoveByOffset(10, 30).Click().Build().Perform();
        }

        public void ClickSearchBar()
        {
            Driver.FindElementByName("Search Facebook").Click();
        }

        public void SearchInSearchBar(String text)
        {
            Driver.FindElementByName("Search FaceBook").SendKeys(text);
        }

        public void PressEnter()
        {
            Actions enter = new Actions(Driver);
            enter.SendKeys(Keys.Enter);
        }

        public void ClickEventsTab()
        {
            Driver.FindElementByName("Events").Click();
        }

        public void ClickPrivateEvent()
        {
            Driver.FindElementByName("Create").Click();
            Driver.FindElementByName("Create Private Event, Only invited guests will see your event.").Click();
        }

        public void EnterEventTitle(String EventTitle)
        {
            Driver.FindElementByName("Event Title").SendKeys(EventTitle);
        }

        public void EnterEventInformation(String EventInformation)
        {
            Driver.FindElementByName("More Info").SendKeys(EventInformation);
        }

        public void ClickCreate()
        {
            Driver.FindElementByName("Create").Click();
        }
    }
}
