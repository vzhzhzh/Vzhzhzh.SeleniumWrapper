using OpenQA.Selenium;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Appointment.Subforms
{
    public class AppointmentAddressSubForm : SubForm
    {
        public override IWebElement SaveButton
        {
            get { return Driver.LongFind(ByNg.Click("getSlotsInfo")); }
        }

        public AppointmentAddressSubForm(DriverHolder driver) : base(driver)
        {
        }

        public override void Clear()
        {
            
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(SaveButton);   
        }

        protected override void FillFields()
        {
            
        }
    }
}