using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class CodeSubform : SubForm
    {
        public CodeSubform(DriverHolder driver)
            : base(driver)
        {
        }

        private IWebElement Code
        {
            get { return Driver.Find(ByNg.Model("data.codeWord")); }
        }

        public override void Clear()
        {
            Driver.Clear(Code);
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(Code);
        }

        protected override void FillFields()
        {
            Driver.SendKeys(Code, "ïïï");
        }
    }
}