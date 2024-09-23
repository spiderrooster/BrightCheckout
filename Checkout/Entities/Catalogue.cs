namespace Checkout.Entities;

public class Catalogue
{
    private List<Product> catalogue = new List<Product>();

    public List<Product> GetCatalogue()
    {
        return catalogue;
    }
 
    public Product CreateProduct(string sku, int price)
    {
        return new Product(sku, price);
    }

    public void AddUpdateProductPrice(Product prod)
    {
        if (!catalogue.Contains(prod))
        {
            this.catalogue.RemoveAll(x => x.Sku == prod.Sku);
        }
        this.catalogue.Add(prod);
    }

    public void AddUpdateProductPrice(string sku, int price)
    {
        Product prod = new Product(sku, price);
        if (!catalogue.Contains(prod))
        {
            this.catalogue.RemoveAll(x => x.Sku == prod.Sku);
        }
        this.catalogue.Add(prod);
    }

    public void RemoveProduct(string sku)
    {
        this.catalogue.RemoveAll(x => x.Sku == sku);
    }
}