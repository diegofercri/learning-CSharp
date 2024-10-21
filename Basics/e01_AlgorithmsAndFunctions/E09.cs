using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E09
    {
        /*
         * Make a program that executes a movement in a matrix of type Integer, making it
         * looks like a toroid, as arguments we will have the FxC matrix and the direction
         * in which it should move.
         */
        public static void Run()
        {
            try
            {
                int[,] matrix = {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }
                };

                Console.WriteLine("Enter the direction to move (up, down, left, right):");
                string direction = Console.ReadLine().ToLower();
                int[,] movedMatrix = MoveToroid(matrix, direction);

                Console.WriteLine("Matrix after moving:");
                PrintMatrix(movedMatrix);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input is not valid. Please enter a valid direction (up, down, left, right).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static int[,] MoveToroid(int[,] matrix, string direction)
        {
            try
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                int[,] newMatrix = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        switch (direction)
                        {
                            case "up":
                                newMatrix[i, j] = matrix[(i + 1) % rows, j];
                                break;
                            case "down":
                                newMatrix[i, j] = matrix[(i - 1 + rows) % rows, j];
                                break;
                            case "left":
                                newMatrix[i, j] = matrix[i, (j + 1) % cols];
                                break;
                            case "right":
                                newMatrix[i, j] = matrix[i, (j - 1 + cols) % cols];
                                break;
                            default:
                                Console.WriteLine("Invalid direction");
                                return matrix;
                        }
                    }
                }
                return newMatrix;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while moving the toroid: {ex.Message}");
                return matrix; // Return the original matrix in case of error
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            try
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while printing the matrix: {ex.Message}");
            }
        }
    }
}
