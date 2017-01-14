using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared
{
    public class TelephonyMock : PageElement
    {
        public TelephonyMock(DriverHolder driver)
            : base(driver)
        {
        }

        private IWebElement IncomingCallButton
        {
            get { return Driver.LongFind(By.Id("widget_mock_call_inbound"), 15); }
        }

        public void GetIncoming()
        {
            Driver.Click(IncomingCallButton);
        }
    }
}
