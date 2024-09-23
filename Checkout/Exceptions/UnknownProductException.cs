namespace Checkout.Exeptions;

    public class UnknownProductException : Exception
    {
        public UnknownProductException(string sku) : base($"No Product found with SKU:{sku}")
        {
        }
    }