using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E11 : Exercise
    {
        public E11()
        {
        }

        /*
         * Method that performs the necessary operations for option 11 of the menu.
         * Calculate if a number is perfect or not.
         * It does not receive or return any value.
         */
        public override void execute()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\nLet's see if it's a perfect number");

                // Create local variables to store the number to be evaluated and the calculations
                int sum = 0, num;

                // Ask the user for the number
                Console.Write("\n\nEnter a number to see if it's perfect: ");
                num = Basics.DataReader.ReadInteger();

                // Only check if the number is perfect if it is positive
                if (num < 0)
                {
                    throw new ArgumentOutOfRangeException("The number cannot be negative.");
                }

                // In this loop, find all numbers that are divisors of the given num.
                for (int i = 1; i < num; i++)
                {
                    // If the number is a divisor, add it to the sum
                    if (num % i == 0)
                    {
                        sum += i;
                    }
                }

                // If the sum of the divisors equals the given number, then it is perfect
                if (num == sum)
                {
                    Console.WriteLine("\nThe number is Perfect!!");
                }
                else
                {
                    Console.WriteLine("\nThe number is NOT Perfect!!");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}
