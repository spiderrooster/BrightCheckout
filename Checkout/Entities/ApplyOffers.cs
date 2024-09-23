namespace Checkout.Entities;

public class ApplyOffers
{
    private List<Offer> offers = new List<Offer>();

    public List<Offer> UpdateAddOffer(string sku, int quantity, decimal discountPrice)
    {
        this.offers.RemoveAll(x => x.Sku == sku);
        this.offers.Add(new Offer(sku, quantity, discountPrice));
        return offers;
    }

    public decimal ApplyOffersToProducts(string sku, int basketQuantity)
    {
        var offer = this.offers.Where(x => x.Sku == sku).FirstOrDefault();
        if (offer == null)
        {
            return 0;
        }
        else
        {
            return basketQuantity / offer.Quantity * offer.DiscountPrice;
        }
    }
}