using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E10
    {
        /*
         * Create a Menu function that displays all the proposed exercises and
         * where the user can select which of them he wants to try. The function
         * returns the option (the number of the exercise) selected and the
         * program calls the function of the corresponding exercise.
         */
        public static void Run()
        {
            while (true)
            {
                try
                {
                    int option = Menu();
                    switch (option)
                    {
                        case 1:
                            E01.Run();
                            break;
                        case 2:
                            E02.Run();
                            break;
                        case 3:
                            E03.Run();
                            break;
                        case 4:
                            E04.Run();
                            break;
                        case 5:
                            E05.Run();
                            break;
                        case 6:
                            E06.Run();
                            break;
                        case 7:
                            E07.Run();
                            break;
                        case 8:
                            E08.Run();
                            break;
                        case 9:
                            E09.Run();
                            break;
                        case 10:
                            E11.Run();
                            break;
                        case 11:
                            E12.Run();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public static int Menu()
        {
            try
            {
                Console.WriteLine("Select an exercise to run:");
                Console.WriteLine("1. Exercise 1");
                Console.WriteLine("2. Exercise 2");
                Console.WriteLine("3. Exercise 3");
                Console.WriteLine("4. Exercise 4");
                Console.WriteLine("5. Exercise 5");
                Console.WriteLine("6. Exercise 6");
                Console.WriteLine("7. Exercise 7");
                Console.WriteLine("8. Exercise 8");
                Console.WriteLine("9. Exercise 9");
                Console.WriteLine("10. Exercise 11");
                Console.WriteLine("11. Exercise 12");
                Console.WriteLine("Enter your choice:");

                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 11)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 12:");
                }
                return option;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while selecting an option: {ex.Message}");
                return -1; // Return -1 to indicate an error
            }
        }
    }
}
