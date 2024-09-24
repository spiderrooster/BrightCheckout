using Checkout.Entities;

namespace CheckoutTest.Entities;

[TestClass]
public class OfferTest
{
    public Offer offer { get; set; }
    public OfferTest()
    {
        this.offer = new Offer("A", 10, 10.00);
    }

    [TestMethod]
    public void TestOffer()
    {
        Assert.AreEqual(offer.Sku, "A");
        Assert.AreEqual(offer.Quantity, 10);
        Assert.AreEqual(offer.DiscountPrice, 10.00);
    }
}