using OpenQA.Selenium;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Data;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.CreditApplicationIncoming
{
    public class IncomingPage : PageElement
    {
        public IWebElement GetTaskButton
        {
            get { return Driver.LongFind(ByNg.Click("startWaiting"), 10); }
        }

        public IncomingPage(DriverHolder driver) : base(driver)
        {
            CreditApplicationTab = new CreditApplicationTab(driver);
            ProductProposalsForm = new ProductProposalsForm(driver);
            TelephonyMock = new TelephonyMock(driver);
        }

        public CreditApplicationTab CreditApplicationTab { get; private set; }
        public ProductProposalsForm ProductProposalsForm { get; private set; }
        public TelephonyMock TelephonyMock { get; private set; }

        public void GetTask()
        {
            Driver.Click(GetTaskButton);
        }

        public void Open()
        {
            Driver.OpenUrl(Settings.OperatorPageUrl);
        }
    }
}