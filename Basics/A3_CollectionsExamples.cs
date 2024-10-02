using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class CollectionsExamples
    {
        static void Main(string[] args)
        {
            List<String> miLista = new List<String>();

            String input = new String("");
            while (!input.Equals("FIN"))
            {
                Console.WriteLine("Introduce el siguiente valor de la cadena (FIN para terminar): ");
                input = Console.ReadLine();
                miLista.Add(input);
            }

            Console.WriteLine("Introduce el valor de la lista que quieres eliminar: ");
            input = Console.ReadLine();
            if (miLista.Contains(input))
            {
                miLista.Remove(input);
            }
            else
            {
                Console.WriteLine("Lo siento, ese valor no existe");
            }

            foreach (String iStr in miLista)
            {
                Console.WriteLine(iStr);
            }
        }
    }
}