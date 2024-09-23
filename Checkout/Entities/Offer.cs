namespace Checkout.Entities;

public class Offer
{
    public Offer(string sku, int quantity, double discountPrice )
    {
        this.Sku = sku;
        this.Quantity = quantity;
        this.DiscountPrice = discountPrice;
    }

    public string Sku { get; set; }
    public int Quantity { get; set; }
    public double DiscountPrice { get; set; }
}