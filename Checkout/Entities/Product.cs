namespace Checkout.Entities;

public class Product
{
    public Product(string sku, decimal price )
    {
        this.Sku = sku;
        this.Price = price;
    }

    public string Sku { get; set; }
    public decimal Price { get; set; }
}