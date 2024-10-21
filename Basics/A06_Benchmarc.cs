using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class Benchmark
    {
        [Benchmark]
        public void Sum()
        {
            var operaciones = new MathOperations();
            operaciones.Sum(10, 20);
        }
        [Benchmark]
        public void Multiplication()
        {
            var operaciones = new MathOperations();

            operaciones.Multiplication(10, 20);
        }
        [Benchmark]
        public void Power()
        {
            var operaciones = new MathOperations();
            operaciones.Power(2, 2);
        }
        [Benchmark]
        public void Power2()
        {
            var operaciones = new MathOperations();
            operaciones.Power2(2, 2);
        }
    }
}