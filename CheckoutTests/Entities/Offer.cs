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
    public void OfferTesttMethod1()
    {
        Console.WriteLine("Hello, World!, OfferTesttMethod1");
    }
}