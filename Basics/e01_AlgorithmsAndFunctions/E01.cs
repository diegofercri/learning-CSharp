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
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative numbers are not valid.");
                }
                if (IsPrime(n))
                {
                    Console.WriteLine($"{n} is a prime number.");
                }
                else
                {
                    Console.WriteLine($"{n} is not a prime number.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input is not a valid integer. Please enter a valid integer.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static bool IsPrime(int n)
        {
            try
            {
                if (n <= 1) return false;
                if (n == 2) return true;
                if (n % 2 == 0) return false;
                for (int i = 3; i <= Math.Sqrt(n); i += 2)
                {
                    if (n % i == 0) return false;
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
