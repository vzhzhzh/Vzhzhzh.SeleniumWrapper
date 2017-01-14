using OpenQA.Selenium;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Appointment.Subforms
{
    public class DateTimeSubform : SubForm
    {
        public IWebElement Date { get { return Driver.LongFind(ByNg.Model("$parent.day")); } }

        public DriverHolder.SelectResult TimeSlotSelect { get { return Driver.FindSelect(ByNg.Model("$parent.time")); } }

        public DateTimeSubform(DriverHolder driver)
            : base(driver)
        {
        }

        public override void Clear()
        {

        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(Date);
        }

        protected override void FillFields()
        {
            Driver.CarefullySendKeys(Date, "19.11.2015");
            TimeSlotSelect.Select.SelectByIndex(1);
        }

        public override void Save()
        {
            
        }
    }
}