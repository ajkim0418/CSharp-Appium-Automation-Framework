using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;

namespace FBDesktop.Pages
{
    class ProfilePage
    {
        WindowsDriver<WindowsElement> Driver;

        public ProfilePage(WindowsDriver<WindowsElement> Driver)
        {
            this.Driver = Driver;
        }

        public void NavigateToProfile()
        {
            Driver.FindElementByName("Profile").Click();
        }

        public Boolean DidProfileLoad()
        {
            return Driver.FindElementByName("Timeline").Displayed;
        }

        public void ClickAddBio()
        {
            Driver.FindElementByName("Add Bio").Click();
        }

        public void EnterBio(String text)
        {
            Actions EnterBio = new Actions(Driver);
            EnterBio.SendKeys(text).Build().Perform();
        }

        public void ClickSave()
        {
            Driver.FindElementByName("Save").Click();
        }

        public void ClickActivityLog()
        {
            Driver.FindElementByName("Activity Log").Click();
        }

        public Boolean DidActivityLogOpen()
        {
            return Driver.FindElementByName("Back").Displayed;
        }
    }
}
