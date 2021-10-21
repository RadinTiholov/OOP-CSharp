namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock productStock;
        [SetUp]
        public void Initialization() 
        {
            productStock = new ProductStock();
        }
        [Test]
        public void AddFunctionWorksCorectly() 
        {
            IProduct product = new Computer("Asus", 1500, 3);
            productStock.Add(product);

            Assert.That(productStock.Count, Is.EqualTo(1));
        }
        [Test]
        public void AddFunctionWorksThrowsExceptionWhenIndenticalProducts()
        {
            IProduct product = new Computer("Asus", 1500, 3);
            IProduct product1 = new Computer("Asus", 1500, 3);
            productStock.Add(product);

            Assert.That(() => productStock.Add(product1), Throws.InvalidOperationException);
        }
        [Test]
        public void CheckIfPRoductIsAvailable()
        {
            IProduct product = new Computer("Asus", 1500, 3);
            IProduct product1 = new Computer("AsusASsdsds", 15000, 3);
            productStock.Add(product);
            productStock.Add(product1);

            Assert.That(productStock.Contains(product), Is.EqualTo(true));
        }

    }
}
