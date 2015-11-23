using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace Vzhzhzh.SeleniumWrapper
{
    public class DriverHolder
    {
        private Lazy<IWebDriver> _lazyDriver = new Lazy<IWebDriver>(CreateDriver);
        public IWebDriver Instance
        {
            get { return _lazyDriver.Value; }
        }

        private const int TimeOut = 3;

        private static IWebDriver CreateDriver()
        {
            var driver =  new ChromeDriver();
                        //new FirefoxDriver();
                        //new PhantomJSDriver();

            driver.Manage().Timeouts()
                .ImplicitlyWait(TimeSpan.FromSeconds(TimeOut))
                .SetScriptTimeout(TimeSpan.FromSeconds(TimeOut));
            driver.Manage().Window.Size = new Size(1600, 1200);
            return driver;
        }

        public  void OpenUrl(string url)
        {
            Instance.Navigate().GoToUrl(url);
        }

        public  IWebElement Find(By by)
        {
            return Instance.FindElement(by);
        }

        public  IWebElement LongGet(By by, int timeout = 30)
        {
            Wait(x => ExpectedConditions.ElementIsVisible(@by), timeout);
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
            var webElement = Find(@by);
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TimeOut));
            return webElement;
        }

        public TResult Find<TResult>(By by, Func<IEnumerable<IWebElement>, TResult> filter)
        {
            return filter(Instance.FindElements(by));
        }

        public SelectResult LongGetSelect(By by)
        {
            var element = LongGet(@by);
            return new SelectResult(element, new SelectElement(element));
        }

        public SelectResult GetSelect(By by)
        {
            var element = Instance.FindElement(@by);
            return new SelectResult(element, new SelectElement(element));
        }

        public void SelectFirstAutocompleteOption(IWebElement element)
        {
            Click(element);
            PressEnter(element);
        }

        public void CarefullySendKeys(IWebElement element, string value)
        {
            Clear(element);
            foreach (var letter in value)
            {
                Thread.Sleep(30);
                element.SendKeys(new string(letter, 1));
            }
            Thread.Sleep(50);
        }

        public void Clear(IWebElement element)
        {
            EnsureAction(e=>e.Clear(), element);
        }

        public void SendKeys(IWebElement element, string text)
        {
            EnsureAction(e =>
            {
                e.SendKeys(text);
            }, element);
        }

        public void PressSpace(IWebElement element)
        {
            EnsureAction(e=>e.SendKeys(Keys.Space), element);
        }

        public void PressEnter(IWebElement element)
        {
            EnsureAction(e=>e.SendKeys(Keys.Enter), element);
        }

        public void Click(IWebElement element)
        {
            EnsureAction(e=>e.Click(), element);
        }

        public void EnsureAction(Action<IWebElement> action, IWebElement element)
        {
            if (element != null)
            {
                Wait(d => ExpectedConditions.ElementToBeClickable(element), 1);    
            }
            
            try
            {
                action(element);
            }
            catch (ElementNotVisibleException)
            {
                // Scroll the page more and retry the click.
                ((IJavaScriptExecutor)Instance).ExecuteScript("window.scrollBy(" + 0 + "," + 200 + ");");
                action(element);
            }
            catch (InvalidOperationException)
            {
                // Scroll the page more and retry the click.
                ((IJavaScriptExecutor)Instance).ExecuteScript("window.scrollBy(" + 0 + "," + 200 + ");");
                action(element);
            } 
        }

        public TResult Wait<TResult>(Func<IWebDriver, TResult> condition, int thesholdInSeconds = 10)
        {
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(thesholdInSeconds));
            return wait.Until(condition);
        }


        public void TearDown()
        {
            try
            {

                if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                {
                    var wrapps = ((IWrapsDriver)Instance);
                    if (wrapps != null)
                    {
                        var takesScreenshot = wrapps.WrappedDriver as ITakesScreenshot;
                        if (takesScreenshot != null)
                        {
                            takesScreenshot.GetScreenshot()
                                .SaveAsFile(TestContext.CurrentContext.Test.FullName + ".jpg", ImageFormat.Jpeg);
                        }
                    }
                }
            }
            catch
            {
            }

            try
            {
                Instance.Quit();
                KillChromeDriverProcess();
                _lazyDriver = new Lazy<IWebDriver>(CreateDriver);
            }
            catch { }
        }

        private static void KillChromeDriverProcess()
        {
            var processes = Process.GetProcessesByName("chromedriver.exe");
            var chromeDriverProcess = processes.FirstOrDefault();
            if (chromeDriverProcess != null)
            {
                chromeDriverProcess.Kill();
            }
        }

        public class SelectResult
        {
            public IWebElement Element { get; private set; }
            public SelectElement Select { get; private set; }

            public SelectResult(IWebElement element, SelectElement select)
            {
                Element = element;
                Select = @select;
            }
        }
    }
}