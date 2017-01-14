using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared
{
    public abstract class SubForm : PageElement
    {
        protected SubForm(DriverHolder driver)
            : base(driver)
        {
        }

        public virtual IWebElement SaveButton
        {
            get { return Driver.Find(ByNg.Click("saveAndShowNextPart")); }
        }

        public abstract void Clear();
        public abstract bool IsOpened();


        public void Fill()
        {
            Clear();
            FillFields();
        }

        public virtual void Refill()
        {
            Clear();
            FillFields();
        }

        protected abstract void FillFields();

        public virtual void Save()
        {
            SaveButton.SendKeys(Keys.Enter);
        }
    }
}