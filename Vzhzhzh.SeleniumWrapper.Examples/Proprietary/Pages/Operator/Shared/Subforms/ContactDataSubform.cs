using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class ContactDataSubform : SubForm
    {
        public IWebElement LastNameInput
        {
            get
            {
                return Driver.Find(ByNg.Model("data.surname"));
            }
        }
        
        public IWebElement NameInput
        {
            get
            {
                return Driver.Find(ByNg.Model("data.name"));
            }
        }
        
        
        public IWebElement StationaryPhoneInput
        {
            get { return Driver.Find(ByNg.Model("data.stationaryPhone")); }
        }

        public IWebElement BirthDateInput
        {
            get
            {
                return Driver.Find(ByNg.Model("data.birthDate"));
            }
        }

        public ContactDataSubform(DriverHolder driver)
            : base(driver)
        {
        }

        

        public override void Clear()
        {
            Driver.Clear(StationaryPhoneInput);
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(StationaryPhoneInput);
        }

        protected override void FillFields()
        {
            Driver.CarefullySendKeys(LastNameInput,"Рудков");
            Driver.CarefullySendKeys(NameInput,"Игорь");
            Driver.CarefullySendKeys(StationaryPhoneInput, "3333333333");
            Driver.SendKeys(BirthDateInput, "10.10.1978");
        }
    }
}