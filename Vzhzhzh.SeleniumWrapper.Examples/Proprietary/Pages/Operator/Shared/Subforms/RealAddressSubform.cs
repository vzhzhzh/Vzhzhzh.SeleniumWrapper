using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class RealAddressSubform : SubForm
    {
        public RealAddressSubform(DriverHolder driver)
            : base(driver)
        {
        }

        private IWebElement IsResidenceSameAsRegistration
        {
            get { return Driver.Find(ByNg.Model("isResidenceSameAsRegistration")); }
        }

        public override void Clear()
        {
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(IsResidenceSameAsRegistration);
        }

        protected override void FillFields()
        {
            Driver.Wait(x => ExpectedConditions.ElementToBeClickable(IsResidenceSameAsRegistration));
            Driver.PressSpace(IsResidenceSameAsRegistration);
        }

        public override void Refill()
        {
        }
    }
}