using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class PersonalDataSubform : SubForm
    {
        public PersonalDataSubform(DriverHolder driver)
            : base(driver)
        {
        }

        private IWebElement Income
        {
            get { return Driver.Find(ByNg.Model("data.income")); }
        }

        public override void Clear()
        {
            Driver.Clear(Income);
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(Income);
        }

        protected override void FillFields()
        {
            Driver.SendKeys(Income, "100000");
        }
    }
}