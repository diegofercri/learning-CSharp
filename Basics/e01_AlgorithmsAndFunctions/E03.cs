using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    /* 
     * Make a function that calculates the nth element of the FIBONACCI series. 1, 1, 2, 3, 5, 8, 13, etc.
     */
    internal class E03
    {
        public static void Run()
        {
            try
            {
                Console.WriteLine("Enter the position of the Fibonacci series you want to calculate:");
                int n = int.Parse(Console.ReadLine());
                int result = Fibonacci(n);
                Console.WriteLine($"The {n}th element in the Fibonacci series is {result}");
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

        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 0)
                    return 0;
                else if (n == 1)
                    return 1;
                else
                    return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating Fibonacci: {ex.Message}");
                return -1; // Devuelve un valor negativo para indicar un error
            }
        }
    }
}
