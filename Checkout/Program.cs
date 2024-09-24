// See https://aka.ms/new-console-template for more information
using Checkout.Entities;
using Checkout.Process;

Product A = new("A", 50.00);
Product B = new("B", 30.00);
Product C = new("C", 20.00);
Product D = new("D", 15.00);

Catalogue catalogue = new Catalogue();

catalogue.AddUpdate(A);
catalogue.AddUpdate(B);
catalogue.AddUpdate(C);
catalogue.AddUpdate(D);

Offer oa = new("A", 3, 130.00);
Offer ob = new("B", 2, 45.00);
Offers offers = new Offers();
offers.UpdateAdd(oa);
offers.UpdateAdd(ob);

Basket basket = new Basket();
CalculateBasket cb = new CalculateBasket(catalogue, offers);

List<string> items = new List<string>
            { "A", "A", "A" };

cb.ScanList(items);
Console.WriteLine("Total:" + cb.Total());
