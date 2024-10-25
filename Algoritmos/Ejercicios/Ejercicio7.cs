using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio7 : Ejercicio
    {
        public Ejercicio7()
        {

        }

        /*
         * Método que comprueba si una cadena es o no palídroma usando otro método
         * El método no recibe ni devuelve ningún valor.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a ver si una palabra es palíndroma");
            // palabra será donde almaceno la cadena a evaluar y palindromo donde almaceno al inversa
            string palabra, palindromo;
            Console.Write("\n\nDame la expresión para saber si es o no palíndroma: ");
            palabra = Console.ReadLine();

            if (palabra.Length == 0)
            {
                Console.WriteLine("La cadena introducida está vacia. Debes escribir algo.");
            }
            else
            {

                // Llamo a la función invertirCadena donde recibe la cadena ya invertida
                palindromo = invertirCadena(palabra, palabra.Length - 1);
                // Muestra la cadena al revés para que la vea el usuario
                Console.WriteLine("\nLa cadena invertido es: " + palindromo);

                // Si la comparación de las dos cadenas es igual 0 es porque son iguales -> palíndromas
                if (palabra.CompareTo(palindromo) == 0)
                {
                    Console.WriteLine("\n\nEs Palíndroma!!\n\n");
                }
                else
                {
                    Console.WriteLine("\n\nNO es Palíndroma!!\n\n");
                }
            }
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /*
         * Método recursivo que invierte un cadena dada como parámetro
         * Recibe la cadena a invertir
         * Recibe la posición por la cual está recorriendo la cadena, comenzando en el final
         * Devuelve la cadena inversa concatenando el resultado en el backtracking
         */
        private string invertirCadena(string palabra, int posicion)
        {
            // Si todavía no he llegado a la primera posición menos entro en el caso recursivo
            if (posicion >= 0)
                // Devuelvo la concatenación de la posición actual más la llamada recursiva
                return palabra[posicion] + invertirCadena(palabra, --posicion);
            // En el caso de estar en la posición -1 de la cadena estaré en el caso base
            // En el caso base solamente devuelvo una cadena vacia para no cambiar nada
            return "";
        }
    }
}
