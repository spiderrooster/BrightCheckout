namespace Checkout.Entities;

public class Offers
{
    private List<Offer> offers = new List<Offer>();

    public List<Offer> UpdateAdd(string sku, int quantity, double discountPrice)
    {
        this.offers.RemoveAll(x => x.Sku == sku);
        this.offers.Add(new Offer(sku, quantity, discountPrice));
        return offers;
    }

    public double ApplyOffer(string sku, int basketQuantity)
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