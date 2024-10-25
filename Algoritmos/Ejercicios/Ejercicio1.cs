using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio1 : Ejercicio
    {

        public Ejercicio1()
        {

        }

        /*
         * Método que pide un número al usuario y comprueba si es primo o no
         * No recibe ningún parámetro ni devuelve valores
         * Solicita un número 
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a ver si un número es primo o no");
            Console.Write("\nDame un número para saber si es primo o no: ");
            int num = LeerDato.LeerEntero();

            // Compruebo que el valor que he leído sea correcto, si no lo es salgo de la opción
            if (LeerDato.getFallo())
            {
                Console.WriteLine("No puedo saber si el número es primo porque el dato introducido no es correcto.");
            }
            else
            {
                // Si no hay error de lectura paso a ver si es primo
                // Llamo a la función esPrimo que me dice true o false según sea el número
                // Evaluo con un if lo que me da la función y muestro un mensaje en relación al mismo
                if (esPrimo(num))
                {
                    Console.WriteLine("El número es un número primo.\n\n");
                }
                else
                {
                    Console.WriteLine("El número NO es un número primo.\n\n");
                }
            }

            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /*
         * Función que recibe el número a evaluar y devuelve true o false según si es o no primo
         */
        private bool esPrimo(int num)
        {
            // Comienzo a dividir por la mitad del número, ya que antes no es posible encontrar un divisor
            int div = num / 2;
            // Mientras que el divisor sea mayor que uno sigo probando si hay algún divisor
            while (div > 1)
            {
                // Si el resto de dividir el número entre el divisor es 0 devuelvo false porque ya sé que no es primo
                if (num % div == 0)
                {
                    return false;
                }
                div--; // Decremento el divisor para serguir evaluando el siguiente número
            }
            // Si no he encontrado ningún divisor que dé resto 0 entonces es primo.
            return true;
        }
    }
}
