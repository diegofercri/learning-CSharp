using System;

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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static string Reverse(string cadena)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reversing the string: {ex.Message}");
                return string.Empty; // Devuelve una cadena vacía en caso de error
            }
        }

        public static bool ArePalindromes(string str1, string str2)
        {
            try
            {
                string invertedStr1 = Reverse(str1);
                string invertedStr2 = Reverse(str2);
                return str1.Equals(invertedStr1) && str2.Equals(invertedStr2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking palindromes: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }
    }
}
