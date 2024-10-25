using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E12
    {
        public static void Run()
        {
            try
            {
                Console.Clear();

                // Create local variables to store the number to be evaluated and the calculations
                int rows;

                // Ask the user for the number
                Console.Write("\n\nEnter a number of rows to paint: ");
                rows = Basics.DataReader.ReadInteger();

                // Only runs if the number is positive
                if (rows < 0)
                {
                    throw new ArgumentOutOfRangeException("The number cannot be negative.");
                }

                for (int i = 0; i <= rows; i++)
                {
                    for (int j = 0; j < rows - i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < 2 * i - 1; k++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine("");
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}
