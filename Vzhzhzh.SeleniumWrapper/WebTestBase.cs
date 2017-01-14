using NUnit.Framework;

namespace Vzhzhzh.SeleniumWrapper
{
    [TestFixture]
    public abstract class WebTestBase
    {
        protected DriverHolder Driver { get; private set; }

        [OneTimeSetUp]
        protected virtual void SetUp()
        {
            Driver = new DriverHolder();
        }

        [TestFixtureTearDown]
        protected virtual void TearDown()
        {
            Driver.TearDown();
        }
    }
}