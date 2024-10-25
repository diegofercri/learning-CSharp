using System;

namespace Basics
{
    internal static class DataReader
    {
        static bool error;
        static internal bool getError() { return error; }
        internal static int ReadInteger()
        {
            try
            {
                error = false;
                return Int32.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                error = true;
                Console.WriteLine("No data was entered. You must enter an integer.");
                return -1;
            }
            catch (FormatException)
            {
                error = true;
                Console.WriteLine("You entered an invalid value. Only integers are allowed.");
                return -2;
            }
            catch (OverflowException)
            {
                error = true;
                Console.WriteLine("The entered value is greater than the allowed maximum. Enter a smaller number.");
                return -3;
            }
        }

        internal static float ReadFloat()
        {
            try
            {
                error = false;
                return float.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                error = true;
                Console.WriteLine("No data was entered. You must enter a decimal number.");
                return -1;
            }
            catch (FormatException)
            {
                error = true;
                Console.WriteLine("You entered an invalid value. Only decimal numbers are allowed.");
                return -2;
            }
            catch (OverflowException)
            {
                error = true;
                Console.WriteLine("The entered value is greater than the allowed maximum. Enter a smaller number.");
                return -3;
            }
        }
    }
}
