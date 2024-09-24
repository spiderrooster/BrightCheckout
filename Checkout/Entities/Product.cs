namespace Checkout.Entities;

public class Product
{
    public Product(string sku, double price )
    {
        this.Sku = sku;
        this.Price = price;
    }

    public string Sku { get; set; }
    public double Price { get; set; }
}