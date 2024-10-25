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
                int spacesRemoved;
                string result = RemoveSpaces(input, out spacesRemoved);
                Console.WriteLine("String without spaces: " + result);
                Console.WriteLine($"Spaces removed: {spacesRemoved}");
                Console.WriteLine($"Characters remaining: {result.Length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static string RemoveSpaces(string input, out int spacesRemoved)
        {
            try
            {
                char[] resultArray = new char[input.Length];
                int index = 0;
                spacesRemoved = 0;

                foreach (char c in input)
                {
                    if (c != ' ')
                    {
                        resultArray[index++] = c;
                    }
                    else
                    {
                        spacesRemoved++;
                    }
                }

                return new string(resultArray, 0, index);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing spaces: {ex.Message}");
                spacesRemoved = 0;
                return string.Empty; // Return an empty string in case of error
            }
        }
    }
}
