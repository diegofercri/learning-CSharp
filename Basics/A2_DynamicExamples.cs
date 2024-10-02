using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class DynamicExamples
    {
        static void Main(string[] args)
        {
            ExampleClass ec = new ExampleClass();

            dynamic retorno = ec.ExampleMethod(2);
            Console.WriteLine(retorno);

            retorno = ec.ExampleMethod("Cadena");
            Console.WriteLine(retorno);


            // Esto no funciona correctamente ya que hacer Enter se altera el tipo int a String
            Console.WriteLine("Introduce la variable que quieres evaluar: ");
            dynamic var_dinamica = Console.Read();
            ec.ExampleMethod(var_dinamica);
            Console.WriteLine(retorno);
        }

        class ExampleClass
        {
            public dynamic ExampleMethod(dynamic d)
            {
                if (d is int)
                {
                    return "La variable es de tipo entero";
                }
                else
                {
                    return "La variable no es de tipo entero";
                }
            }
        }
    }
}