using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio9 : Ejercicio
    {
        public Ejercicio9()
        {

        }

        /*
         * Método que realiza las operaciones necesarias para la opción 9 del menú.
         * Mover una matriz como si fuera un toroide.
         * No recibe ni devuelve ningún valor.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a rotar una matriz toroide");
            int filas, colum; // Número de filas y columnas de la matriz
            // Pido al usuario el tamaño de la matriz
            Console.Write("\n\nDime el número de filas que quieres en la Matriz de origen: ");
            filas = LeerDato.LeerEntero();
            Console.Write("Dime el número de columnas que quieres en la Matriz de origen: ");
            colum = LeerDato.LeerEntero();
            int[,] matToro = new int[filas, colum];
            int valor = 0;
            // Recorro la matriz y la inicializo con valores por defecto
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    matToro[i, j] = valor;
                    valor++;
                }
            }

            mostrarMatriz(matToro);

            // Ahora pido al usuario la dirección en la que quiere rotar la matriz
            // Para ello lo hago dentro de un bucle permitiendo que el usuario
            // pueda realizar varias rotaciones, hasta que quiera salir.
            int direccion = 0, pasos = 0;
            do
            {
                // Muestro las posibles opciones que existen.
                Console.WriteLine("\n\n1.- Rotar a la izquierda.");
                Console.WriteLine("2.- Rotar a la derecha.");
                Console.WriteLine("3.- Rotar arriba.");
                Console.WriteLine("4.- Rotar abajo.");
                Console.WriteLine("0.- Terminar de rotar y volver al menú principal.");
                // Pido la dirección al usuario
                Console.Write("Indica la dirección de rotación del toroide: ");
                direccion = LeerDato.LeerEntero();

                // Si el usuario pulsa una opción de dirección correcta hago cosas
                if (direccion >= 1 && direccion <= 4)
                {
                    // Pido el número de pasos de la rotación
                    Console.WriteLine("Dime la cantidad de movimientos de rotación del toroide: ");
                    pasos = LeerDato.LeerEntero();

                    // Creo un bucle donde llamo a la función que realiza la rotación
                    // tantas veces como pasos me ha dicho el usuario
                    for (int i = 0; i < pasos; i++)
                    {
                        // Llamo a la función que realiza un movimiento del toroide.
                        rotar(matToro, direccion);
                    }
                }

                // En cada movimiento muestro el estado del Toroide con la función
                mostrarMatriz(matToro);
            } while (direccion != 0);
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /*
         * Método que comprueba la dirección de la rotación y llama al método correspondiente.
         * No recibe ni devuelve ningún valor.
         */
        private void rotar(int[,] matToro, int direccion)
        {
            // Evaluo la dirección de la rotación
            switch (direccion)
            {
                // Si son columnas es la 2ª dimensión
                case 1:
                    // Llamo al método que hace la rotación en esa dirección
                    rotarIzquierda(matToro);
                    break;
                case 2:
                    // Llamo al método que hace la rotación en esa dirección
                    rotarDerecha(matToro);
                    break;
                // Si son filas es la 1ª dimensión
                case 3:
                    // Llamo al método que hace la rotación en esa dirección
                    rotarArriba(matToro);
                    break;
                case 4:
                    // Llamo al método que hace la rotación en esa dirección
                    rotarAbajo(matToro);
                    break;
            }
        }

        /*
         * Método que realiza una rotación a la izquierda de la matriz
         * No recibe ni devuelve ningún valor.
         */
        private void rotarIzquierda(int[,] matToro)
        {
            // Declaro un array auxiliar donde almaceno los datos antes de perderlos
            int[] aux = new int[matToro.GetLength(0)];

            // Recorro el array, por cada posición guardo el valor de la matriz
            // en el array para después recuperarlo en la matriz de nuevo
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = matToro[i, 0];
            }

            // Ahora recorro el resto de la matriz desplazando las columnas a la izquierda
            for (int i = 1; i < matToro.GetLength(1); i++)
            {
                for (int j = 0; j < matToro.GetLength(0); j++)
                {
                    matToro[j, i - 1] = matToro[j, i];
                }
            }

            // Finalmente recupero la primera columna del array y la almaceno en la última
            for (int i = 0; i < aux.Length; i++)
            {
                matToro[i, matToro.GetLength(1) - 1] = aux[i];
            }
        }

        /*
         * Método que realiza una rotación a la derecha de la matriz
         * No recibe ni devuelve ningún valor.
         */
        private void rotarDerecha(int[,] matToro)
        {
            // Declaro un array auxiliar donde almaceno los datos antes de perderlos
            int[] aux = new int[matToro.GetLength(0)];

            // Recorro el array, por cada posición guardo el valor de la matriz
            // en el array para después recuperarlo en la matriz de nuevo
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = matToro[i, matToro.GetLength(1) - 1];
            }

            // Ahora recorro el resto de la matriz desplazando las columnas a la izquierda
            for (int i = matToro.GetLength(1) - 2; i >= 0; i--)
            {
                for (int j = matToro.GetLength(0) - 1; j >= 0; j--)
                {
                    matToro[j, i + 1] = matToro[j, i];
                }
            }

            // Finalmente recupero la última columna del array y la almaceno en la primera
            for (int i = 0; i < aux.Length; i++)
            {
                matToro[i, 0] = aux[i];
            }
        }

        /*
         * Método que realiza una rotación hacia arriba de la matriz
         * No recibe ni devuelve ningún valor.
         */
        private void rotarArriba(int[,] matToro)
        {
            // Declaro un array auxiliar donde almaceno los datos antes de perderlos
            int[] aux = new int[matToro.GetLength(1)];

            // Recorro el array, por cada posición guardo el valor de la matriz
            // en el array para después recuperarlo en la matriz de nuevo
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = matToro[0, i];
            }

            // Ahora recorro el resto de la matriz desplazando las filas hacia arriba
            for (int i = 1; i < matToro.GetLength(0); i++)
            {
                for (int j = 0; j < matToro.GetLength(1); j++)
                {
                    matToro[i - 1, j] = matToro[i, j];
                }
            }

            // Finalmente recupero la primera fila del array y la almaceno en la última
            for (int i = 0; i < aux.Length; i++)
            {
                matToro[matToro.GetLength(0) - 1, i] = aux[i];
            }
        }

        /*
         * Método que realiza una rotación hacia abajo de la matriz
         * No recibe ni devuelve ningún valor.
         */
        private void rotarAbajo(int[,] matToro)
        {
            // Declaro un array auxiliar donde almaceno los datos antes de perderlos
            int[] aux = new int[matToro.GetLength(1)];

            // Recorro el array, por cada posición guardo el valor de la matriz
            // en el array para después recuperarlo en la matriz de nuevo
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = matToro[matToro.GetLength(0) - 1, i];
            }

            // Ahora recorro el resto de la matriz desplazando las filas hacia abajo
            for (int i = matToro.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = matToro.GetLength(1) - 1; j >= 0; j--)
                {
                    matToro[i + 1, j] = matToro[i, j];
                }
            }

            // Finalmente recupero la primera fila del array y la almaceno en la última
            for (int i = 0; i < aux.Length; i++)
            {
                matToro[0, i] = aux[i];
            }
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
    }
}
