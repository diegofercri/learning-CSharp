using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio2 : Ejercicio
    {
        private float a, b, c;

        public Ejercicio2()
        {

        }

        /*
         * Método que realiza la opción 2 de la función
         * No recibe ningún argumento ni devuelve nada.
         */
        public override void ejecutar()
        {
            introducirDatos();
            
            if (LeerDato.getFallo())
            {
                Console.WriteLine("No puedo saber el tipo de triángulo porque alguno de los valores no es válido.");
            }
            else
            {
                // Evaluo las diferentes opciones que tengo y muestro un mensaje acorde a cada una de ellas
                if (a >= (b + c))
                {
                    Console.WriteLine("\nNo se trata de un triángulo.\n\n");
                }
                else
                {
                    if ((a * a) == ((b * b) + (c * c)))
                    {
                        Console.WriteLine("\nEs un triángulo rectángulo.\n\n");
                    }
                    else
                    {
                        if ((a * a) > ((b * b) + (c * c)))
                        {
                            Console.WriteLine("\nEs un triángulo obtusángulo.\n\n");
                        }
                        else
                        {
                            Console.WriteLine("\nEs un triángulo acutángulo.\n\n");
                        }
                    }
                }
            }
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        private void introducirDatos()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a ver qué tipo de triángulo me das");
            // Piso por consola los 3 lados, dando por sentado que el A será el mayor
            Console.Write("\n\nDame la longitud del lado A: ");
            a = LeerDato.LeerFloat();
            Console.Write("Dame la longitud del lado B: ");
            b = LeerDato.LeerFloat();
            Console.Write("Dame la longitud del lado C: ");
            c = LeerDato.LeerFloat();
        }
    }
}
