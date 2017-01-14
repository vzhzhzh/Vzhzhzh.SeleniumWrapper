using OpenQA.Selenium;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Appointment.Subforms
{
    public class ConfirmAppointmentSubform : SubForm
    {
        public IWebElement ConfirmAppointment { get { return Driver.Find(ByNg.Click("confirmAppointment")); } }
        public virtual IWebElement ProcessNextCall
        {
            get { return Driver.Find(ByNg.Model("model.processNextCall")); }
        }

        public virtual IWebElement Confirm
        {
            get { return Driver.Find(ByNg.Click("actions.confirm")); }
        }
        public ConfirmAppointmentSubform(DriverHolder driver) : base(driver)
        {
        }

        

        public override void Clear()
        {
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(ConfirmAppointment);
        }

        protected override void FillFields()
        {
        }

        public override void Save()
        {
            Driver.PressEnter(ConfirmAppointment);
            Driver.PressSpace(ProcessNextCall);
            Driver.PressEnter(Confirm);
        }

    }
}