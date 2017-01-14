using System.Threading;
using NUnit.Framework;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Data;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Appointment;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Tasks.Appointment
{
    internal class OperatorConfirmsMeetingAppointment : WebTestBase
    {
        private MeetingAppointmentPage _appointmentPage;

        [Test]
        [Ignore("dummy reason")]
        public void HappyPath()
        {
            Runner
                .Create(Driver)
                .SetSetup(() =>
                {
                    _appointmentPage = new MeetingAppointmentPage(Driver);
                    OperatorLogsIn();
                })
                .SetTest(() =>
                {
                    OperatorAsksForATask();
                    OperatorFillsApplicationForm();
                })
                .SetConditions()
                .Execute();
            WebAssert.IsElementPresent(_appointmentPage.GetTaskButton);
        }

        public void OperatorLogsIn()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.LogIn(Users.MeetingAppointment);
        }

        public void OperatorAsksForATask()
        {
            _appointmentPage.GetTask();
            _appointmentPage.Call();
        }


        public void OperatorFillsApplicationForm()
        {
            _appointmentPage.AppointmentApplicationTab.Open();
            Thread.Sleep(4000);
            _appointmentPage.AppointmentApplicationTab.FillApplication();
        }
    }
}
