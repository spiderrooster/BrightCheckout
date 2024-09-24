namespace Checkout.Exeptions;

    public class NoOffersFoundException : Exception
    {
        public NoOffersFoundException() : base($"No offers found.")
        {
        }
    }