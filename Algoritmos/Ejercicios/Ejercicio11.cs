using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio11 : Ejercicio
    {
        public Ejercicio11()
        {

        }

        /*
         * Método que realiza las operaciones necesarias para la opción 11 del menú.
         * Calcular si un número es o no perfecto.
         * No recibe ni devuelve ningún valor.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a ver si es un número perfecto");
            // Creo las variables locales que usaré para almacenar el número a evaluar y los cálculos
            int suma = 0, num;

            // Pido el número al usuario
            Console.Write("\n\nIntroduce un número para ver si es perfecto: ");
            num = LeerDato.LeerEntero();

            // Solamente compruebo si el número es perfecto en el caso de que sea positivo
            if (num >= 0)
            {

                // En este bucle busco todos los números que son diviseros del num dado.
                for (int i = 1; i < num; i++)
                {
                    // Si el número es divisor entonces lo añado a la suma
                    if (num % i == 0)
                    {
                        suma += i;
                    }
                }

                // Si la suma de los divisores es igual al número dado entonces es perfecto
                if (num == suma)
                {
                    Console.WriteLine("\nEl número es Perfecto!!");
                }
                else
                {
                    Console.WriteLine("\nEl número NO es Perfecto!!");

                }
            }
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }
    }
}
