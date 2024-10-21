using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    /* 
     * Make a function that tells us if a number is prime.
     */
    internal class E01
    {
        public static void Run()
        {
            try
            {
                Console.WriteLine("Enter an integer:");
                int number = int.Parse(Console.ReadLine());
                if (IsPrime(number))
                {
                    Console.WriteLine($"{number} is a prime number.");
                }
                else
                {
                    Console.WriteLine($"{number} is not a prime number.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input is not a valid integer. Please enter a valid integer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static bool IsPrime(int number)
        {
            try
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;
                for (int i = 3; i <= Math.Sqrt(number); i += 2)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking if the number is prime: {ex.Message}");
                return false;
            }
        }
    }
}
