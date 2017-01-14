using OpenQA.Selenium;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator
{
    public class CreditApplicationTab : ApplicationTab
    {
        public virtual IWebElement Tab
        {
            get { return Driver.Find(By.LinkText("Оформление заявки")); }
        }

        public CreditApplicationTab(DriverHolder driver)
            : base(
                driver,
                new ContactDataSubform(driver),
                new PassportDataSubform(driver),
                new RegistrationAddressSubform(driver),
                new RealAddressSubform(driver),
                new EmploymentSubform(driver),
                new PersonalDataSubform(driver),
                new SkipSubform(driver),
                new CodeSubform(driver),
                new SkipSubform(driver),
                new SaveSubform(driver)           
                )
        {

        }

        public override void Open()
        {
            Tab.Click();
        }
    }
}