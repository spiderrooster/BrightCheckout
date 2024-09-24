using Checkout.Entities;

namespace CheckoutTest.Entities;

[TestClass]
public class ProductTest
{
    public Product product { get; set; }
    public ProductTest()
    {
        product = new Product("B", 15.00);
    }

    [TestMethod]
    public void TestProduct()
    {
        Assert.AreEqual(product.Sku, "B");
        Assert.AreEqual(product.Price, 15.00);
    }
}