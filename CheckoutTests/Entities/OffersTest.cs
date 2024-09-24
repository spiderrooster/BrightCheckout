using Checkout.Entities;

namespace CheckoutTest.Entities;

[TestClass]
public class OffersTest
{
    public Offers offers { get; set; }
    public Offer A = new Offer("A", 3, 50);
    public Offer B = new Offer("B", 2, 45);
    public OffersTest()
    {
        this.offers = new Offers();
        this.offers.UpdateAdd(A.Sku, A.Quantity, A.DiscountPrice);
        this.offers.UpdateAdd(B.Sku, B.Quantity, B.DiscountPrice);
        }

    [TestMethod]
    public void TestOffer()
    {
        Assert.AreEqual(offers.GetOffers().FirstOrDefault(x => x.Sku == A.Sku).Sku, A.Sku);
        Assert.AreEqual(offers.GetOffers().FirstOrDefault(x => x.Sku == A.Sku).Quantity, A.Quantity);
        Assert.AreEqual(offers.GetOffers().FirstOrDefault(x => x.Sku == A.Sku).DiscountPrice, A.DiscountPrice);
        Assert.AreEqual(offers.GetOffers().FirstOrDefault(x => x.Sku == B.Sku).Sku, B.Sku);
        Assert.AreEqual(offers.GetOffers().FirstOrDefault(x => x.Sku == B.Sku).Quantity, B.Quantity);
        Assert.AreEqual(offers.GetOffers().FirstOrDefault(x => x.Sku == B.Sku).DiscountPrice, B.DiscountPrice);
    }
}