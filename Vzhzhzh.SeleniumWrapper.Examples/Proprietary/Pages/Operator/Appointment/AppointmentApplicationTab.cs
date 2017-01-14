using OpenQA.Selenium;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Data;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Appointment.Subforms;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Appointment
{
    public class MeetingAppointmentPage : PageElement
    {
        public AppointmentApplicationTab AppointmentApplicationTab { get; private set; }

        public IWebElement GetTaskButton
        {
            get { return Driver.LongFind(ByNg.Click("getNewTasks"), 10); }
        }
        
        public IWebElement ContinueTaskProcessingButton
        {
            get { return Driver.LongFind(ByNg.Click("continueProcessing(t.id)"), 3, false); }
        }
        
        public IWebElement CallButton
        {
            get { return Driver.LongFind(ByNg.Click("makeCall(contactPhone.phoneId)")); }
        }

        public MeetingAppointmentPage(DriverHolder driver) : base(driver)
        {
            AppointmentApplicationTab = new AppointmentApplicationTab(driver);
        }

        public void GetTask()
        {
            if (ContinueTaskProcessingButton != null)
            {
                Driver.PressEnter(ContinueTaskProcessingButton);
            }
            else
            {
                Driver.PressEnter(GetTaskButton);    
            }
        }

        public void Call()
        {
            if (CallButton!=null)
            {
                Driver.PressEnter(CallButton);    
            }
            
        }

        public void Open()
        {
            Driver.OpenUrl(Settings.OperatorPageUrl);
        }
    }

    public class AppointmentApplicationTab : ApplicationTab
    {
        public virtual IWebElement Tab
        {
            get { return Driver.Find(By.LinkText("Назначение встречи")); }
        }

        public AppointmentApplicationTab(DriverHolder driver) : base(
            driver, 
            new AppointmentAddressSubForm(driver),
            new DateTimeSubform(driver),
            new ConfirmAppointmentSubform(driver)
            )
        {
        }

        public override void Open()
        {
            Driver.Click(Tab);
        }
    }
}
