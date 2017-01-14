using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class PassportDataSubform : SubForm
    {
        public PassportDataSubform(DriverHolder driver) : base(driver)
        {
        }

        private IWebElement SeriesAndNumber
        {
            get { return Driver.Find(ByNg.Model("data.passportSeriesAndNumber")); }
        }

        private IWebElement Division
        {
            get { return Driver.Find(ByNg.Model("data.division")); }
        }

        private IWebElement Agency
        {
            get { return Driver.Find(ByNg.Model("data.agency")); }
        }

        private IWebElement IssueDate
        {
            get { return Driver.Find(ByNg.Model("data.issueDate")); }
        }

        private IWebElement BirthPlace
        {
            get { return Driver.Find(ByNg.Model("data.birthPlace")); }
        }

        public override void Clear()
        {
            Driver.Clear(SeriesAndNumber);
            Driver.Clear(Division);
            Driver.Clear(Agency);
            Driver.Clear(IssueDate);
            Driver.Clear(BirthPlace);
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(SeriesAndNumber);
        }

        protected override void FillFields()
        {
            Driver.SendKeys(SeriesAndNumber, "3333333333");
            Driver.SelectFirstAutocompleteOption(Division);
            Driver.SelectFirstAutocompleteOption(Agency);
            Driver.SendKeys(IssueDate, "10102011");
            Driver.SendKeys(BirthPlace, "123");
        }
    }
}