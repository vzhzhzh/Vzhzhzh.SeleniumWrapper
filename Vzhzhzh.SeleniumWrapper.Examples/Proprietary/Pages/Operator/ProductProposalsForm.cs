using OpenQA.Selenium;

namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Pages.Operator
{
    public class ProductProposalsForm : PageElement
    {
        public ProductProposalsForm(DriverHolder driver)
            : base(driver)
        {
        }

        public static class ProductTypes
        {
            public const string PlatinumCard = "Кредитная карта Platinum";
        }

        private DriverHolder.SelectResult Products
        {
            get { return Driver.LongGetSelect(ByNg.Model("selectedProduct")); }
        }
        
        private IWebElement OfferButton
        {
            get { return Driver.Find(ByNg.Click("proposeProduct(selectedProduct)")); }
        }

        public void OfferProduct(string product)
        {
            Products.Select.SelectByText(product);
            if (OfferButton.Enabled)
            {
                Driver.Click(OfferButton);
            }
        }
    }
}