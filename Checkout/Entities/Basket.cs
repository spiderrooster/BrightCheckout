namespace Checkout.Entities;

public class Basket
{
    private List<Product> BasketOfProducts = new List<Product>();
    
    public void AddProductToBacket(Product prod)
    {
        BasketOfProducts.Add(prod);
    }
    public void RemoveProductFromBasket(Product prod)
    {
        this.BasketOfProducts.Remove(prod);
    }
    public int RemoveAllProductFromBasket(Product prod)
    {
        return this.BasketOfProducts.RemoveAll(x => x == prod);
    }

     public int RemoveAllProductFromBasketSku(string sku, int price)
    {
        return this.BasketOfProducts.RemoveAll(x => x.Sku == sku);
    }
}