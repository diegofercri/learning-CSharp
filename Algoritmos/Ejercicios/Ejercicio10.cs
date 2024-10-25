using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio10 : Ejercicio
    {
        public Ejercicio10() { }

        public override void ejecutar()
        {
            Console.WriteLine("\nEn esta opción volvemos a ver el menú de nuevo");
            Console.WriteLine("Pulse INTRO para continuar.");
            Console.ReadLine();
        }
    }
}
