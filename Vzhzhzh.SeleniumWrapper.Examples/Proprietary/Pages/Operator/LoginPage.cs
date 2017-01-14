using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Data;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator
{
    public class LoginPage : PageElement
    {
        public LoginPage(DriverHolder driver)
            : base(driver)
        {
        }

        private IWebElement Login
        {
            get { return Driver.Find(By.Id("Login")); }
        }

        private IWebElement Password
        {
            get { return Driver.Find(By.Id("Password")); }
        }

        private IWebElement Submit
        {
            get { return Driver.Find(By.CssSelector("input[value='Войти в систему']")); }
        }

        public void LogIn(LoginInfo loginInfo)
        {
            Driver.OpenUrl(Settings.IndexUrl);
            Driver.SendKeys(Login, loginInfo.Login);
            Driver.SendKeys(Password, loginInfo.Password);
            var submit = Submit;
            Driver.Click(submit);
            Driver.Wait(x => ExpectedConditions.StalenessOf(submit));
        }
    }
}