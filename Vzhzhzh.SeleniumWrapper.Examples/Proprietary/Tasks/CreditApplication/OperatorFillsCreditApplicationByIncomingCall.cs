using NUnit.Framework;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Data;
using Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Tasks.CreditApplication
{
    internal class OperatorFillsCreditApplicationByIncomingCall : WebTestBase
    {
        private IncomingPage _incomingPage;

        [Test]
        [Ignore("dummy reason")]
        public void HappyPath()
        {
            Runner
                .Create(Driver)
                .SetSetup(() =>
                {
                    _incomingPage = new IncomingPage(Driver);
                    OperatorLogsIn();
                })
                .SetTest(() =>
                {
                    OperatorAsksForATask();
                    OperatorOffersPlatinumCard();
                    OperatorOpensApplicationForm();
                    OperatorFillsApplicationForm();
                })
                .SetConditions()
                .Execute();
            WebAssert.IsElementPresent(_incomingPage.GetTaskButton);
        }

        public void OperatorLogsIn()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.LogIn(Users.CreditAppIncoming);
        }

        public void OperatorAsksForATask()
        {
            _incomingPage.GetTask();
            _incomingPage.TelephonyMock.GetIncoming();
        }

        public void OperatorOffersPlatinumCard()
        {
            _incomingPage.ProductProposalsForm.OfferProduct(ProductProposalsForm.ProductTypes.PlatinumCard);
        }

        public void OperatorOpensApplicationForm()
        {
            _incomingPage.CreditApplicationTab.Open();
        }

        public void OperatorFillsApplicationForm()
        {
            _incomingPage.CreditApplicationTab.FillApplication();
        }
    }
}
