namespace ecom.CustomLogic
{
    public class Mathfunctions
    {
        //The function below is for returning the discounted price by recieving the discount integer value and decimal number price as parameters
        public string discounted_price(int discount, double price)
        {
            double discount_percentage = (double) discount / 100;
            double savings = discount_percentage * price;
            double newPrice = price - savings;

            newPrice = Math.Round(newPrice, 0);

            return newPrice.ToString();
        }

        public string discounted_price_cents(int discount, double price)
        {
            double discount_percentage = (double)discount / 100;
            double savings = discount_percentage * price;
            double newPrice = price - savings;

            newPrice = Math.Round(newPrice, 2);
            newPrice = Math.Round(100 * (newPrice - Math.Round(newPrice, 0)), 0);

            return newPrice.ToString();
        }
    }
}
