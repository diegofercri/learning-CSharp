using System;

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
            try
            {
                Console.WriteLine("Enter the price of the item:");
                // The use of decimal is due to its better accuracy for decimal calculations
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter the amount inserted:");
                decimal amountInserted = decimal.Parse(Console.ReadLine());

                CalculateChange(price, amountInserted);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input is not a valid number. Please enter a valid decimal number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void CalculateChange(decimal price, decimal amountInserted)
        {
            try
            {
                if (amountInserted < price)
                {
                    Console.WriteLine("Error: The amount inserted is less than the price of the item.");
                    return;
                }

                decimal change = amountInserted - price;
                Console.WriteLine($"Total change to be returned: {change} euros");

                int[] coinAndBillValues = { 500, 200, 100, 50, 20, 10, 5, 2, 1 }; // Values in cents
                int changeInCents = (int)(change * 100); // Convert change to cents

                foreach (int value in coinAndBillValues)
                {
                    int numberOfUnits = changeInCents / value;
                    if (numberOfUnits > 0)
                    {
                        Console.WriteLine($"{numberOfUnits} unit(s) of {value / 100.0} euros");
                        changeInCents %= value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating change: {ex.Message}");
            }
        }
    }
}
