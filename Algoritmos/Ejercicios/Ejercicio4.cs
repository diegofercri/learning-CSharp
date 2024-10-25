using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio4 : Ejercicio
    {

        public Ejercicio4()
        {

        }

        /*
         * Método que realiza la opción 4 del menú,
         * sacar un array con una submatriz de una matriz.
         * No recibe ni devuelve ningún valor.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a sacar una Submatriz de una Matriz");
            int filas, colum; // Número de filas y columnas de la matriz
            int x, y; // Posición inicial de la submatriz
            // Pido al usuario el tamaño de la matriz
            Console.Write("\n\nDime el número de filas que quieres en la Matriz de origen: ");
            filas = LeerDato.LeerEntero();
            Console.Write("Dime el número de columnas que quieres en la Matriz de origen: ");
            colum = LeerDato.LeerEntero();
            int[,] matOrin = new int[filas, colum];
            int valor = 0;
            // Recorro la matriz y la inicializo con valores por defecto
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    matOrin[i, j] = valor;
                    valor++;
                }
            }

            // Muestro la matriz con sus valores iniciales.
            mostrarMatriz(matOrin);

            // Pido la posición de la submatriz al usuario
            Console.Write("\n\nDame la posición x de la submatriz: ");
            x = LeerDato.LeerEntero();
            Console.Write("Dame la posición y de la submatriz: ");
            y = LeerDato.LeerEntero();

            // Creo un array con el tamaño exacto de valores que necesito, restando a los totales las posiciones dadas
            int[] array = new int[(filas - x) * (colum - y)];
            valor = 0;
            // Bucle que recorre la submatriz, empiezo por la posición que me ha dado el usuario y
            // finalizo en la última fila y columna de la matriz.
            for (int i = x; i < matOrin.GetLength(0); i++)
            {
                for (int j = y; j < matOrin.GetLength(1); j++)
                {
                    // Asigno al Array cada uno de los valores de la submatriz
                    try
                    {
                        array[valor] = matOrin[i, j];
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("Durante el proceso se ha intentado acceder una posición fuera del rango del array.");
                    }
                    // Incremento después la posición del indice del array
                    valor++;
                }
            }

            // Después muestro el array llamando a un método para ello.
            Console.WriteLine("\n\nAhora puedes ver el Array resultante: ");
            mostrarArray(array);
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /*
         * Método que recibe un array de 2 dimensiones, lo recorre y muestra sus valores.
         * No devuelve ningún valor.
         */
        private void mostrarMatriz(int[,] matriz)
        {
            Console.WriteLine("\n\nLa matriz es:\n[");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(" " + matriz[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("]\n");
        }

        /*
         * Método que recibe un array unidimensional, lo recorre y muestra sus valores.
         * No devuelve ningún valor.
         */
        private void mostrarArray(int[] array)
        {
            Console.Write("\n\nEl Array es:\n[ ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("]\n");
        }
    }
}
