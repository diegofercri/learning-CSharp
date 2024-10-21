using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class MathOperations
    {
        public double Sum(double a, double b)
        {
            return a + b;
        }

        public double Multiplication(double a, double b)
        {
            return a * b;
        }

        public double Power(double @base, double exponent)
        {
            return Math.Pow(@base, exponent);
        }

        public double Power2(double @base, double exponent)
        {
            if (exponent == 0)
                return 1;

            var result = @base;

            for (int i = 1; i < exponent; i++)
            {
                result = result * @base;
            }

            return result;
        }
    }
}