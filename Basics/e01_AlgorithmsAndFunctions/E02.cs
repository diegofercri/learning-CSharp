using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.e01_AlgorithmsAndFunctions
{
    /*
     * Design an algorithm that, given the lengths of the three sides of a triangle (A, B, C),
     * determines what type of triangle it is, according to the following cases:
     * 
     * - If A >= B + C
     * It is not a triangle
     * 
     * - If A2
     * = B2
     * + C2
     * It is a right triangle
     * 
     * - If A2
     * > B2
     * + C2
     * It is an obtuse triangle
     * 
     * - If A2
     * < B2
     * + C2
     * It is an acute-angled triangle
     */
    internal class E02
    {
        public static void Run()
        {
            Console.WriteLine("Enter the length of side A:");
            double A = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the length of side B:");
            double B = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the length of side C:");
            double C = double.Parse(Console.ReadLine());

            if (A >= B + C || B >= A + C || C >= A + B)
            {
                Console.WriteLine("It is not a triangle.");
            }
            else if (Math.Pow(A, 2) == Math.Pow(B, 2) + Math.Pow(C, 2) ||
                     Math.Pow(B, 2) == Math.Pow(A, 2) + Math.Pow(C, 2) ||
                     Math.Pow(C, 2) == Math.Pow(A, 2) + Math.Pow(B, 2))
            {
                Console.WriteLine("It is a right triangle.");
            }
            else if (Math.Pow(A, 2) > Math.Pow(B, 2) + Math.Pow(C, 2) ||
                     Math.Pow(B, 2) > Math.Pow(A, 2) + Math.Pow(C, 2) ||
                     Math.Pow(C, 2) > Math.Pow(A, 2) + Math.Pow(B, 2))
            {
                Console.WriteLine("It is an obtuse triangle.");
            }
            else
            {
                Console.WriteLine("It is an acute triangle.");
            }
        }
    }
}
