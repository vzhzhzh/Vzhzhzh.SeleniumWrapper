using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class SaveSubform : SubForm
    {
        public SaveSubform(DriverHolder driver)
            : base(driver)
        {
        }

        public override IWebElement SaveButton
        {
            get { return Driver.Find(ByNg.Click("finish")); }
        }

        public virtual IWebElement ProcessNextCall
        {
            get { return Driver.Find(ByNg.Model("model.processNextCall")); }
        }

        public virtual IWebElement Confirm
        {
            get { return Driver.Find(ByNg.Click("actions.confirm")); }
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

        public override void Save()
        {
            Driver.PressEnter(SaveButton);
            Driver.PressSpace(ProcessNextCall);
            Driver.PressEnter(Confirm);
        }
    }
}