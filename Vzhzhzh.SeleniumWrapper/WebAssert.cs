using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper
{
    public static class WebAssert
    {
        public static void IsEqual(string expectedValue, string actualValue, string elementDescription)
        {
            if (expectedValue != actualValue)
            {
                throw new AssertionException(String.Format("AssertIsEqual Failed: '{0}' didn't match expectations. Expected [{1}], Actual [{2}]", elementDescription, expectedValue, actualValue));
            }
        }

        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                Thread.Sleep(50);
                bool b = element.Displayed && element.Size.Height > 0 && element.Size.Width >0;
                return b;
            }
            catch
            {
                return false;
            }
        }

        public static void ElementPresent(IWebElement element, string elementDescription)
        {
            if (!IsElementPresent(element))
                throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static bool IsElementPresent(ISearchContext context, By searchBy)
        {
            try
            {
                bool b = context.FindElement(searchBy).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ElementPresent(ISearchContext context, By searchBy, string elementDescription)
        {
            if (!IsElementPresent(context, searchBy))
                throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static void ElementsPresent(IWebElement[] elements, string elementDescription)
        {
            if (elements.Length == 0)
                throw new AssertionException(String.Format("AssertElementsPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static void ElementText(IWebElement element, string expectedValue, string elementDescription)
        {
            ElementPresent(element, elementDescription);
            string actualtext = element.Text;
            if (actualtext != expectedValue)
            {
                throw new AssertionException(String.Format("AssertElementText Failed: Value for '{0}' did not match expectations. Expected: [{1}], Actual: [{2}]", elementDescription, expectedValue, actualtext));
            }
        }

    }
}