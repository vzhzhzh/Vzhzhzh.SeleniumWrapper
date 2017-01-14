using System.Linq;
using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class EmploymentSubform : SubForm
    {
        public EmploymentSubform(DriverHolder driver)
            : base(driver)
        {
        }

        private DriverHolder.SelectResult EmploymentType
        {
            get { return Driver.FindSelect(ByNg.Model("data.occupation.employmentType")); }
        }

        private IWebElement PensionAge
        {
            get
            {
                return Driver.Find(ByNg.Model("data.occupation.unEmploymentCause"),
                    elements => elements.First(x => x.GetAttribute("value") == "pension_age"));
            }
        }

        public override void Clear()
        {
        }

        public override bool IsOpened()
        {
            return WebAssert.IsElementPresent(EmploymentType.Element);
        }

        protected override void FillFields()
        {
            Driver.Wait(d => EmploymentType.Element.Displayed);
            EmploymentType.Select.SelectByText("Не работаю");
            Driver.Click(PensionAge);
        }
    }
}