using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string result = RemoveSpaces(input);
            Console.WriteLine("String without spaces: " + result);
        }

        public static string RemoveSpaces(string input)
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
    }
}
