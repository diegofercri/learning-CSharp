using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio5 : Ejercicio
    {

        public Ejercicio5()
        {

        }

        /*
         * Método que realiza las funciones para la opción 5 del menú.
         * No reibe ni devuelve ningún parámetro.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a quitar los espacios en blanco de una cadena");
            // Solicito la cadena completa al usuario
            Console.Write("\n\nDame la frase de origen: ");
            string cadenaOrigen = Console.ReadLine();
            // Variable que almacena el resultado, la cadena sin espacios
            string cadenaFinal = "";
            // Recorro la cadena original completa, posición a posición.
            for (int i = 0; i < cadenaOrigen.Length; i++)
            {
                // Por cada caracter de la cadena miro si no es un espacio
                if (cadenaOrigen[i] != ' ')
                {
                    // Si no es un espacio lo concateno en el resultado
                    cadenaFinal += cadenaOrigen[i];
                }
            }
            // Muestro la cadena resultante sin espacios.
            Console.WriteLine("\n\nLa cadena resultante es:" + cadenaFinal);
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }
    }
}
