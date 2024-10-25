using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio3 : Ejercicio
    {
        public Ejercicio3()
        {

        }

        /*
         * Método que realiza la opción 3 del menú,
         * para ello usará la llamada a la función recursiva Fibo
         * No recibe ni devuelve ningún valor
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nSerie de Fibonacci");
            // Pido el número de elementos de la serie de Fibonacci a mostrar
            int n;
            Console.Write("\n\nDame el número de elementos de la Serie de Fibonacii que quieres ver: ");
            n = LeerDato.LeerEntero();
            // Muestra por pantalla la cadena que me devuelve la función Fibo
            Console.WriteLine(Fibo(1, n, 0, 0));
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /*
         * Función recusiva que recibe:
         * El número del elemento actual
         * El número de elementos a mostrar
         * El elemento actual
         * El elemento siguiente
         * La función devuelve una cadena de caracteres con la serie completa
         */
        public string Fibo(int i, int n, int f1, int f2)
        {
            // Creo un caso base para el primer elemento, donde comienzo la cadena con el valor 0
            // y la concateno con la siguiente llamada recursiva
            if (i == 1)
            {
                return "[ 0 " + Fibo(++i, n, f2, f2 + 1);
            }
            else // Si no es el primero compruebo si he terminado
            {
                // El caso recursivo sirve para mostrar el elemento actual y realizar la siguiente llamada recursiva
                if (i <= n)
                {
                    if (f1 + f2 > 0)
                        return f2 + " " + Fibo(++i, n, f2, f1 + f2);
                    else
                        return "] \nNo podemos seguir mostrando más valores porque el rango de representación es pequeño.";
                }
            }
            // En el caso base que finaliza la función devuelvo el cierre de la cadena.
            return "]";
        }
    }
}
