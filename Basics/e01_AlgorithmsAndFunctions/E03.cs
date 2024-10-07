using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.e01_AlgorithmsAndFunctions
{
    /*
     * Make a function that calculates the nth element of the FIBONACII series. 1, 1, 2, 3, 5, 8, 13, etc.
     */
    internal class E03
    {
        public static void Run()
        {
            Console.WriteLine("Enter the position of the Fibonacci series you want to calculate:");
            int n = int.Parse(Console.ReadLine());

            int result = Fibonacci(n);
            Console.WriteLine($"The {n}th element in the Fibonacci series is {result}");
        }

        public static int Fibonacci(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
