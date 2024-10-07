using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E08
    {
        /*
         * Perform a procedure that shows us the change in coins to be made by a can
         * vending machine, the procedure receives as parameters the value of the can
         * and the amount entered, if the amount is less than the price an error
         * message must be shown.
         */
        public static void Run()
        {
            Console.WriteLine("Enter the price of the item:");
            // The use of decimal is due to its better accuracy for decimal calculations
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount inserted:");
            decimal amountInserted = decimal.Parse(Console.ReadLine());

            CalculateChange(price, amountInserted);
        }

        public static void CalculateChange(decimal price, decimal amountInserted)
        {
            if (amountInserted < price)
            {
                Console.WriteLine("Error: The amount inserted is less than the price of the item.");
                return;
            }

            decimal change = amountInserted - price;
            Console.WriteLine($"Total change to be returned: {change} euros");

            int[] coinValues = { 100, 50, 20, 10, 5, 2, 1 }; // Coin values in cents
            int changeInCents = (int)(change * 100); // Convert change to cents

            foreach (int coin in coinValues)
            {
                int numberOfCoins = changeInCents / coin;
                if (numberOfCoins > 0)
                {
                    Console.WriteLine($"{numberOfCoins} coin(s) of {coin / 100.0} euros");
                    changeInCents %= coin;
                }
            }
        }
    }
}
