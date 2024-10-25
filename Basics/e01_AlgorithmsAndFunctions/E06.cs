using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    class E06
    {
        /*
         * Make a function that receives a binary number and returns its natural equivalent
         */
        public static void Run()
        {
            try
            {
                Console.WriteLine("Enter a binary number:");
                string binaryInput = Console.ReadLine();
                int decimalResult = BinaryToDecimal(binaryInput);
                Console.WriteLine($"The decimal equivalent of {binaryInput} is {decimalResult}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input is not a valid binary number. Please enter a valid binary number.");
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

        public static int BinaryToDecimal(string binary)
        {
            try
            {
                int decimalValue = 0;
                int baseValue = 1; // 2^0
                for (int i = binary.Length - 1; i >= 0; i--)
                {
                    if (binary[i] != '1' && binary[i] != '0')
                    {
                        throw new ArgumentOutOfRangeException("Only 1 and 0 are accepted in binary numbers.");
                    }
                    if (binary[i] == '1')
                    {
                        decimalValue += baseValue;
                    }
                    baseValue *= 2;
                }
                return decimalValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while converting binary to decimal: {ex.Message}");
                return -1; // Return -1 to indicate an error
            }
        }
    }
}
