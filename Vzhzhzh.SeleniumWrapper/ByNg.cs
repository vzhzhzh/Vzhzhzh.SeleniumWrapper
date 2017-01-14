using System.Linq;
using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper
{
    public class ByNg
    {
        public static By Model(string ngModelName)
        {
            return By.CssSelector(string.Format("[ng-model='{0}']", ngModelName));
        }

        public static By Click(string ngClickFunction)
        {
            if (ngClickFunction.Last() != ')')
            {
                ngClickFunction = ngClickFunction + "()";
            }
            return By.CssSelector(string.Format("[ng-click='{0}']", ngClickFunction));
        }
    }
}