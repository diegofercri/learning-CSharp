using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E05
    {
        /*
         * Design a procedure that removes whitespace from a string
         * (without using the methods provided by the String class).
         */
        public static void Run()
        {
            try
            {
                Console.WriteLine("Enter a string:");
                string input = Console.ReadLine();
                string result = RemoveSpaces(input);
                Console.WriteLine("String without spaces: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static string RemoveSpaces(string input)
        {
            try
            {
                char[] resultArray = new char[input.Length];
                int index = 0;
                foreach (char c in input)
                {
                    if (c != ' ')
                    {
                        resultArray[index++] = c;
                    }
                }
                return new string(resultArray, 0, index);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing spaces: {ex.Message}");
                return string.Empty; // Devuelve una cadena vacía en caso de error
            }
        }
    }
}
