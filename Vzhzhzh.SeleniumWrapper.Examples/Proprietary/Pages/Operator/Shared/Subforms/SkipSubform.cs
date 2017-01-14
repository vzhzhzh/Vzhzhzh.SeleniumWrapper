using System.Threading;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared.Subforms
{
    public class SkipSubform : SubForm
    {
        public SkipSubform(DriverHolder driver)
            : base(driver)
        {
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
            Thread.Sleep(400);
            base.Save();
        }
    }
}