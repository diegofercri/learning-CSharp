using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.e01_AlgorithmsAndFunctions
{
    class E06
    {
        /*
         * Make a function that receives a binary number and returns its natural equivalent
         */
        public static void Run()
        {
            Console.WriteLine("Enter a binary number:");
            string binaryInput = Console.ReadLine();

            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine($"The decimal equivalent of {binaryInput} is {decimalResult}");
        }

        public static int BinaryToDecimal(string binary)
        {
            int decimalValue = 0;
            int baseValue = 1; // 2^0

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    decimalValue += baseValue;
                }
                baseValue *= 2;
            }

            return decimalValue;
        }
    }
}
