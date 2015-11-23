namespace Vzhzhzh.SeleniumWrapper
{
    public abstract class PageElement
    {
        protected readonly DriverHolder Driver;

        protected PageElement(DriverHolder driver)
        {
            Driver = driver;
        }
    }
}