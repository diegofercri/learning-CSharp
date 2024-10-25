using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio8 : Ejercicio
    {
        public Ejercicio8()
        {

        }

        /*
         * Método que realiza las operaciones necesarias para la opción 8 del menú.
         * No recibe ni devuelve ningún valor.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a calcular el cambio de una máquina expendedora");
            // Declaro las variables que almacenan el precio del producto, el dinero introducido
            // y el cambio que tendré que darle
            float precio, dinero, resto;
            // Creo un array con los tipos de monedas que existen.
            float[] tipoMonedas = { 2.0f, 1.0f, 0.5f, 0.2f, 0.1f, 0.05f, 0.02f, 0.01f };
            // Creo un array con la cantidad de monedas necesarias de cada tipo.
            int[] cuentaMonedas = { 0, 0, 0, 0, 0, 0, 0, 0 };
            // Solicito los valores al usuario:
            Console.Write("\n\nDime el precio del producto a comprar: ");
            precio = LeerDato.LeerFloat();
            Console.Write("\nDime la cantidad de dinero introducida: ");
            dinero = LeerDato.LeerFloat();

            // En este bucle compruebo que el cliente haya introducido dinero suficiente para el producto que quiere comprar.
            while (dinero < precio)
            {
                // Si no es así le muestro un mesaje de error y le pido más dinero.
                Console.Write("\nEl dinero introducido es insuficiente, introduce de nuevo el dinero: ");
                dinero = LeerDato.LeerFloat();
            }

            // Calculo el cambio que debo darle al cliente,
            // para evitar el problema de las operaciones con decimales uso el redondeo a dos decimales
            resto = (float)Math.Round(dinero - precio, 2);
            // Bucle que calcula monedas a devolver mientras que aún tenga que dinero que devolver
            while (resto > 0)
            {
                // Evaluo la cantidad a devolver y compruebo los casos de mayor a menor para evitar
                // dar más monedas de las necesarias.
                switch (resto)
                {
                    // En cada caso de moneda comprubo si es mayor que el resto que falta por devolver
                    // Aumento el contador de monedas de ese valor y resto ese valor a la cantidad a devolver.
                    case float f when f >= tipoMonedas[0]:
                        resto = (float)Math.Round(resto - tipoMonedas[0], 2);
                        cuentaMonedas[0]++;
                        break;
                    case float f when f >= tipoMonedas[1]:
                        resto = (float)Math.Round(resto - tipoMonedas[1], 2);
                        cuentaMonedas[1]++;
                        break;
                    case float f when f >= tipoMonedas[2]:
                        resto = (float)Math.Round(resto - tipoMonedas[2], 2);
                        cuentaMonedas[2]++;
                        break;
                    case float f when f >= tipoMonedas[3]:
                        resto = (float)Math.Round(resto - tipoMonedas[3], 2);
                        cuentaMonedas[3]++;
                        break;
                    case float f when f >= tipoMonedas[4]:
                        resto = (float)Math.Round(resto - tipoMonedas[4], 2);
                        cuentaMonedas[4]++;
                        break;
                    case float f when f >= tipoMonedas[5]:
                        resto = (float)Math.Round(resto - tipoMonedas[5], 2);
                        cuentaMonedas[5]++;
                        break;
                    case float f when f >= tipoMonedas[6]:
                        resto = (float)Math.Round(resto - tipoMonedas[6], 2);
                        cuentaMonedas[6]++;
                        break;
                    case float f when f >= tipoMonedas[7]:
                        resto = (float)Math.Round(resto - tipoMonedas[7], 2);
                        cuentaMonedas[7]++;
                        break;
                }
            }

            // Recorro el array de cantidad de monedas y muestro la cantidad de cada una de ellas a devolver.
            Console.WriteLine("Las monedas a devolver son: ");
            for (int i = 0; i < tipoMonedas.Length; i++)
            {
                if (cuentaMonedas[i] != 0)
                {
                    Console.WriteLine($"{cuentaMonedas[i]} monedas de {tipoMonedas[i]} euros.");
                }
            }
            Console.WriteLine("Pulsa INTRO para continuar.");
            Console.ReadLine();
        }
    }
}
