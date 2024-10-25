// Añadimos las librerias necesarias del programa
using System;

namespace Algoritmos
{
    /*
    Esta es la clase principal del programa, en ella se incluye el main
    No será instanciada y contiene todas las funciones necesarias para la ejecución
    No tiene atributos al no ser necesario dado su forma de enfocar el proyecto.
     */
    public class Algorit
    {
        /*
         * Metodo principal, llama al menú del programa,
         * evalua la opción que el usuario a seleccionado y llama al metodo
         * del ejercicio correspondiente.
         * Recibe un array de tipo string con los argumentos
         * No devuelve nada al sistema.
         */
        public static void Main(string[] args)
        {
            Menu miMenu = new Menu();
            miMenu.llamarEjercicio();
        }
    }
}
