using Checkout.Entities;

namespace Checkout.Process;

public class CalculateBasket
{

    private Catalogue catalogue;
    private Offers offers;
    private Basket basket;
    public CalculateBasket(Catalogue catalogue, Offers offers, Basket basket)
    {
        this.catalogue = catalogue;
        this.offers = offers;
        this.basket = basket;
    }

       public void Scan(string sku, int times)
        {
            if (basket.ContainsKey(sku))
            {
                basket[sku] += times;
            }
            else
            {
                basket.Add(sku, times);
            }
        }

        public double Total
        {
            get
            {
                var total = 0;
                foreach (var group in basket)
                {
                    var sku = group.Key;
                    var number_of_items = group.Value;
                    total += offers.ApplyOffer(sku, number_of_items);
                    total += number_of_items * catalogue.GetPrice(group.Key);
                }
                return total;
            }
        }
}