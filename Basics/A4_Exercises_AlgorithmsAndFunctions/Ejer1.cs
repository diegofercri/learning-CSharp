using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Exercises_AlgorithmsAndFunctions
{
    internal class Ejer01
    {
        static void Main()
        {
            Console.WriteLine("Introduce un número entero:");
            int numero = int.Parse(Console.ReadLine());

            if (EsPrimo(numero))
            {
                Console.WriteLine($"{numero} es un número primo.");
            }
            else
            {
                Console.WriteLine($"{numero} no es un número primo.");
            }
        }

        static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;
            if (numero == 2) return true;
            if (numero % 2 == 0) return false;

            /*
             *  Si un número N no tiene divisores menores o iguales a su raíz cuadrada,
             *  entonces no tendrá divisores mayores que su raíz cuadrada. Esto se debe a que
             *  cualquier divisor mayor que la raíz cuadrada tendría que multiplicarse por
             *  un divisor menor que la raíz cuadrada para dar N. Con esto hacemos el
             *  algoritmo mucho mas eficiente.
             */

            for (int i = 3; i <= Math.Sqrt(numero); i += 2)
            {
                if (numero % i == 0) return false;
            }

            return true;
        }
    }
}