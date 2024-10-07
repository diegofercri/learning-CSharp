using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.e01_AlgorithmsAndFunctions
{
    internal class E04
    {
        /*
         * Create a procedure that, given a square array and the position of a subarray
         * within it, returns the contents of that subarray in a one-dimensional array.
         */
        public static void Run()
        {
            int[,] matrix = {
                { 01, 02, 03, 04 },
                { 05, 06, 07, 08 },
                { 09, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };


            Console.WriteLine("Enter the starting row of the submatrix:");
            int startRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the starting column of the submatrix:");
            int startCol = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the size of the submatrix:");
            int submatrixSize = int.Parse(Console.ReadLine());


            int[] submatrix = ExtractSubmatrix(matrix, startRow, startCol, submatrixSize);

            Console.WriteLine("Submatrix elements:");
            foreach (int element in submatrix)
            {
                Console.Write(element + " ");
            }
        }

        public static int[] ExtractSubmatrix(int[,] matrix, int startRow, int startCol, int size)
        {
            int[] submatrix = new int[size * size];
            int index = 0;

            for (int i = startRow; i < startRow + size; i++)
            {
                for (int j = startCol; j < startCol + size; j++)
                {
                    submatrix[index++] = matrix[i, j];
                }
            }

            return submatrix;
        }
    }
}
