using System;

namespace Algoritmos
{
    internal static class LeerDato
    {
        static bool fallo;

        static internal bool getFallo() { return fallo; }

        internal static int LeerEntero()
        {
            try
            {
                fallo = false;
                return Int32.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                fallo = true;
                Console.WriteLine("No has introducido ningún dato. Debes introducir algún número entero.");
                return -1;
            }
            catch (FormatException)
            {
                fallo = true;
                Console.WriteLine("No has introducido un valor válido. Solamente puedes introducir números enteros.");
                return -2;
            }
            catch (OverflowException)
            {
                fallo = true;
                Console.WriteLine("El valor introducido es mayor que el máximo permitido. Introduce un número más pequeño.");
                return -3;
            }
        }

        internal static float LeerFloat()
        {
            try
            {
                fallo = false;
                return float.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                fallo = true;
                Console.WriteLine("No has introducido ningún dato. Debes introducir algún número decimal.");
                return -1;
            }
            catch (FormatException)
            {
                fallo = true;
                Console.WriteLine("No has introducido un valor válido. Solamente puedes introducir números decimales.");
                return -2;
            }
            catch (OverflowException)
            {
                fallo = true;
                Console.WriteLine("El valor introducido es mayor que el máximo permitido. Introduce un número más pequeño.");
                return -3;
            }
        }
    }
}
