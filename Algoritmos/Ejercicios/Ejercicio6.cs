using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio6 : Ejercicio
    {
        public Ejercicio6 ()
        { 

        }

        /*
         * Método que realiza las operaciones necesarias para la opción 6 del menú
         * No recibe ni devuelve ningún valor.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a pasar un número de Binario a Decimal");
            // Creo las variables necesarias para las operaciones.
            // Binario almacena el número que me dan
            // potencia se usa para ver la potencia de cada dígito binario, será un contador
            // deci se usa para almacenar el valor resultante
            int binario, potencia = 0, deci = 0;
            // Pido el número binario, no valido el número
            Console.Write("Dame el número binario a convertir: ");
            binario = LeerDato.LeerEntero();

            // Mientras que el binario siga siendo > 0 tengo que seguir operando
            while (binario > 0)
            {
                // En cada iteración sumo en deci el valor que tenía + el resultado de la potencia de ese dígito
                deci += (binario % 10) * (Int32)Math.Pow(2, potencia);
                // Divido entre 10 el número original para quitar el dígito que ya he calculado
                binario /= 10;
                // Incremento la potencia de 2 para la siguiente operación
                potencia++;
            }
            // Muestro el resultado
            Console.WriteLine($"\n\nEl número en decimal es: {deci}");
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }
    }
}
