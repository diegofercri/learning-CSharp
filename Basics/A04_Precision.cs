using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class Precision
    {

        public static void Run()
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();
            int operacion = 10 / 4;
            timeMeasure.Stop();
            Console.WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine($"Precision: {(1.0 / Stopwatch.Frequency).ToString("E")} segundos");
            if (Stopwatch.IsHighResolution)
                Console.WriteLine("Alta precisión");
            else
                Console.WriteLine("Baja precisión");
        }
    }
}