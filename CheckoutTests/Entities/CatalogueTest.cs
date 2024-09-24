using Checkout.Entities;
using Checkout.Exeptions;

namespace CheckoutTest.Entities;

[TestClass]
public class CatalogueTest
{
    public Catalogue catalogue { get; set; }
    
    public CatalogueTest()
    {
        this.catalogue = new Catalogue();
    }

    [TestMethod]
    public void AddToCatalogue()
    {
        catalogue.AddUpdate("A", 2.00);
        catalogue.AddUpdate("B", 4.00);
        Assert.AreEqual(2.00, catalogue.GetPrice("A"));
        Assert.AreEqual(4.00, catalogue.GetPrice("B"));
    }

    [TestMethod]
    public void UpdateProductInCatalogue()
    {
        catalogue.AddUpdate("A", 2.00);
        Assert.AreEqual(2.00, catalogue.GetPrice("A"));
        catalogue.AddUpdate("A", 4.00);
        Assert.AreEqual(4.00, catalogue.GetPrice("A"));
    }

    [TestMethod]
    [ExpectedException(typeof(UnknownProductException))]
    public void RemoveFromCatalogue()
    {
        catalogue.AddUpdate("A", 2.00);
        Assert.AreEqual(2.00, catalogue.GetPrice("A"));
        catalogue.RemoveProduct("A");
        catalogue.GetPrice("A");
    }
}