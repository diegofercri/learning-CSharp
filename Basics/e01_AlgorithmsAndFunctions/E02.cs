﻿using System;

namespace Basics.e01_AlgorithmsAndFunctions
{
    /*
     * Design an algorithm that, given the lengths of the three sides of a triangle (A, B, C),
     * determines what type of triangle it is, according to the following cases:
     * 
     * - If A >= B + C
     *   It is not a triangle
     * 
     * - If A^2 = B^2 + C^2
     *   It is a right triangle
     * 
     * - If A^2 > B^2 + C^2
     *   It is an obtuse triangle
     * 
     * - If A^2 < B^2 + C^2
     *   It is an acute-angled triangle
     */
    internal class E02
    {
        public static void Run()
        {
            try
            {
                Console.WriteLine("Enter the length of side A:");
                double A = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the length of side B:");
                double B = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the length of side C:");
                double C = double.Parse(Console.ReadLine());

                // Identify the hypotenuse and the two other sides
                double hypotenuse, cathetus1, cathetus2;
                if (A >= B && A >= C)
                {
                    hypotenuse = A;
                    cathetus1 = B;
                    cathetus2 = C;
                }
                else if (B >= A && B >= C)
                {
                    hypotenuse = B;
                    cathetus1 = A;
                    cathetus2 = C;
                }
                else
                {
                    hypotenuse = C;
                    cathetus1 = A;
                    cathetus2 = B;
                }

                // Perform the triangle type checks
                if (hypotenuse >= cathetus1 + cathetus2)
                {
                    Console.WriteLine("It is not a triangle.");
                }
                else if (Math.Pow(hypotenuse, 2) == Math.Pow(cathetus1, 2) + Math.Pow(cathetus2, 2))
                {
                    Console.WriteLine("It is a right triangle.");
                }
                else if (Math.Pow(hypotenuse, 2) > Math.Pow(cathetus1, 2) + Math.Pow(cathetus2, 2))
                {
                    Console.WriteLine("It is an obtuse triangle.");
                }
                else
                {
                    Console.WriteLine("It is an acute triangle.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input is not a valid number. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
