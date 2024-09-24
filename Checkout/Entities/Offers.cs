using Checkout.Exeptions;
namespace Checkout.Entities;

public class Offers
{
    private List<Offer> offers = new List<Offer>();

    public void UpdateAdd(string sku, int quantity, double discountPrice)
    {
        this.offers.RemoveAll(x => x.Sku == sku);
        this.offers.Add(new Offer(sku, quantity, discountPrice));
    }

    public void UpdateAdd(Offer offer)
    {
        this.offers.RemoveAll(x => x.Sku == offer.Sku);
        this.offers.Add(offer);
    }

    public List<Offer> GetOffers()
    {
        if(offers.Count()>0)
        {
        return this.offers;
        }
        else
        {
            throw new NoOffersFoundException();
        }
    }

    public double ApplyOffer(string sku, ref int basketQuantity)
    {
        var offer = this.offers.Where(x => x.Sku == sku).FirstOrDefault();
        if (offer == null)
        {
            return 0;
        }
        else
        {
            var result = ( basketQuantity / offer.Quantity) *  offer.DiscountPrice;
            basketQuantity = basketQuantity % offer.Quantity;

            return  result;
        }
    }
}