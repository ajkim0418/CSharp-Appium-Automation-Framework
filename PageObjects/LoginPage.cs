using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;


namespace FBDesktop.Pages
{
    class LoginPage
    {
        WindowsDriver<WindowsElement> Driver;

        public LoginPage(WindowsDriver<WindowsElement> Driver)
        {
            this.Driver = Driver;
        }

        public void EnterUsername(String username)
        {
            WindowsElement usernameField = Driver.FindElementByName("Username Field");
            if (usernameField != null)
            {
                usernameField.SendKeys(Keys.Control + "a");
                usernameField.SendKeys(Keys.Delete);
            }
            usernameField.SendKeys(username);
        }

        public void EnterPassword(String password)
        {
            Driver.FindElementByName("Password Field").SendKeys(password);
        }

        public void ClickLogIn()
        {
            Driver.FindElementByName("Log In").Click();
        }

        public Boolean IsLoginSuccessful()
        {
            return Driver.FindElementByName("News Feed").Displayed;
        }
    }
}
