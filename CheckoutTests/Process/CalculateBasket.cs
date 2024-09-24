using Checkout.Process;
using Checkout.Entities;

namespace CheckoutTest.Process;

[TestClass]
public class CalculateBasketTest
{
    private CalculateBasket calculateBasket;

    public CalculateBasketTest()
    {
        Product A = new("A", 50.00);
        Product B = new("B", 30.00);
        Product C = new("C", 20.00);
        Product D = new("D", 15.00);
        Catalogue cat = new Catalogue();
        cat.AddUpdate(A);
        cat.AddUpdate(B);
        cat.AddUpdate(C);
        cat.AddUpdate(D);

        Offer oa = new("A", 3, 100.00);
        Offers off = new Offers();

        calculateBasket = new CalculateBasket(cat, off);
    }

    [TestMethod]
    public void Scan()
    {
        calculateBasket.Scan("A");
        calculateBasket.Scan("A");
        calculateBasket.Scan("B");

        Assert.AreEqual(calculateBasket.GetBasket().Count(), 2);
        Assert.AreEqual(calculateBasket.GetBasket().Where(x => x.Key == "A").SingleOrDefault().Value, 2);
        Assert.AreEqual(calculateBasket.GetBasket().Where(x => x.Key == "B").SingleOrDefault().Value, 1);
    }

    [TestMethod]
    public void ScanList()
    {
        List<string> items = new List<string>
            { "A", "A", "A" };
        calculateBasket.ScanList(items);

        Assert.AreEqual(calculateBasket.GetBasket().Count(), 2);
        Assert.AreEqual(calculateBasket.GetBasket().Where(x => x.Key == "A").SingleOrDefault().Value, 3);
    }

        [TestMethod]
    public void TotalNoOffers()
    {
        List<string> items = new List<string>
            { "D", "D", "D" };
        calculateBasket.ScanList(items);

        Assert.AreEqual(calculateBasket.GetBasket().Count(), 3);
        Assert.AreEqual(calculateBasket.GetBasket().Where(x => x.Key == "D").SingleOrDefault().Value, 3);
        Assert.AreEqual(calculateBasket.Total(), 45.00);
    }

        public void TotalOffers()
    {
        List<string> items = new List<string>
            { "A", "A", "A" };
        calculateBasket.ScanList(items);

        Assert.AreEqual(calculateBasket.GetBasket().Count(), 3);
        Assert.AreEqual(calculateBasket.GetBasket().Where(x => x.Key == "D").SingleOrDefault().Value, 3);
        Assert.AreEqual(calculateBasket.Total(), 150.00);
    }
}