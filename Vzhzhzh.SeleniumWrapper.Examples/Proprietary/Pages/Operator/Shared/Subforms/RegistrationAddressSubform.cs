using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class RegistrationAddressSubform : SubForm
    {
        public RegistrationAddressSubform(DriverHolder driver)
            : base(driver)
        {
        }

        private IWebElement PostalCode
        {
            get { return Driver.Find(ByNg.Model("model.postalCode")); }
        }

        private IWebElement OmitPostalCode
        {
            get { return Driver.Find(ByNg.Model("model.omitPostalCode")); }
        }

        private IWebElement PrivateHouse
        {
            get { return Driver.Find(ByNg.Model("viewData.privateHouse")); }
        }

        private IWebElement Street
        {
            get { return Driver.Find(ByNg.Model("model.street")); }
        }

        private IWebElement House
        {
            get { return Driver.Find(ByNg.Model("bizData.house")); }
        }

        private IWebElement Apartment
        {
            get { return Driver.Find(ByNg.Model("viewData.apartment")); }
        }

        public override void Clear()
        {
            if (!OmitPostalCode.Selected)
            {
                Driver.Clear(PostalCode);
                Driver.Clear(Street);
                Driver.Clear(House);
                Driver.Clear(Apartment);
            }
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(PostalCode);
        }

        protected override void FillFields()
        {
            if (OmitPostalCode.Selected)
            {
                Driver.PressSpace(OmitPostalCode);
            }

            Driver.CarefullySendKeys(PostalCode, "630054");
            Driver.SelectFirstAutocompleteOption(Street);
            Driver.SendKeys(House, "1");

            if (PrivateHouse.Selected)
            {
                Driver.PressSpace(PrivateHouse);
            }
            Driver.SendKeys(Apartment, "1");
        }
    }
}