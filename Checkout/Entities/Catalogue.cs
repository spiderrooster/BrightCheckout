using Checkout.Exeptions;

namespace Checkout.Entities;

public class Catalogue
{
    private List<Product> catalogue = new List<Product>();

    public List<Product> GetCatalogue()
    {
        return catalogue;
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

    public decimal GetPriceForProduct(string sku)
    {
        var product = this.catalogue.Where(x => x.Sku == sku).FirstOrDefault();
        if (product == null)
        {
            throw new UnknownProductException(sku);
        }
        else
        {
            return product.Price;
        }
    }
}