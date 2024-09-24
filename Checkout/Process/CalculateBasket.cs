using Checkout.Entities;

namespace Checkout.Process;

public class CalculateBasket
{
    private Catalogue catalogue;
    private Offers offers;
    private Basket basket;
    public CalculateBasket(Catalogue catalogue, Offers offers)
    {
        this.catalogue = catalogue;
        this.offers = offers;
        this.basket = new Basket();
    }

    public Basket GetBasket()
    {
        return basket;
    }

    public void ScanList(List<String> items)
    {
        foreach (String sku in items)
        {
            this.Scan(sku);
        }
    }

    public void Scan(string sku)
    {
        if (basket.ContainsKey(sku))
        {
            basket[sku] += 1;
        }
        else
        {
            basket.Add(sku, 1);
        }
    }

    public double Total()
    {
        double total = 0;
        foreach (var group in basket)
        {
            var sku = group.Key;
            var baskQuantity = group.Value;
            total += offers.ApplyOffer(sku, ref baskQuantity);
            total += baskQuantity * catalogue.GetPrice(group.Key);

        }
        return total;
    }
}