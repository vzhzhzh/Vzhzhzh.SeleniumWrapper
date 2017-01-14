using System;
using System.Linq;
using System.Threading;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator.Shared
{
    public abstract class ApplicationTab : PageElement
    {
        private readonly SubForm[] _subforms;

        protected ApplicationTab(DriverHolder driver, SubForm first, params SubForm[] subforms) : base(driver)
        {
            var firstFormArray = new[] {first};
            _subforms = subforms.Any() ? firstFormArray.Concat(subforms).ToArray() : firstFormArray;
        }

        public abstract void Open();

        public virtual void FillApplication()
        {
            for (int i = 0; i < _subforms.Length; i++)
            {
                var current = _subforms[i];
                SubForm next = null;
                if (i < _subforms.Length - 1)
                {
                    next = _subforms[i + 1];
                }
                try
                {
                    current.Fill();
                    current.Save();
                    Thread.Sleep(500);
                    if (next != null && !next.IsOpened())
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(300);
                    current.Refill();
                    current.Save();
                }
            }
        }
    }
}