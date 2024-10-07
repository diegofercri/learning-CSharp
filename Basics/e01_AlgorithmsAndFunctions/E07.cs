using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E07
    {
        /*
         * Make a function that tells us if 2 character strings are palindromes.
         * To do this you must make a function that uses recursion to flip a
         * string given by the user (for example, from “Hello” it would return
         * “aloH”). The recursive function will be called “Reverse(string)”.
         * Analyze what the base case will be (what length a string should be to
         * make it trivial to flip it) and how to go from case “n-1” to case “n”
         * (for example, if you have already inverted the first 5 letters, what
         * would happen to the one in the sixth position).
         */
        public static void Run()
        {
            Console.WriteLine("Enter the first string:");
            string str1 = Console.ReadLine();

            Console.WriteLine("Enter the second string:");
            string str2 = Console.ReadLine();

            bool arePalindromes = ArePalindromes(str1, str2);
            if (arePalindromes)
            {
                Console.WriteLine("Both strings are palindromes.");
            }
            else
            {
                Console.WriteLine("The strings are not palindromes.");
            }
        }

        public static string Reverse(string cadena)
        {
            if (cadena.Length <= 1)
            {
                return cadena;
            }
            else
            {
                return Reverse(cadena.Substring(1)) + cadena[0];
            }
        }

        public static bool ArePalindromes(string str1, string str2)
        {
            string invertedStr1 = Reverse(str1);
            string invertedStr2 = Reverse(str2);

            return str1.Equals(invertedStr1) && str2.Equals(invertedStr2);
        }
    }
}
