using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class DynamicExamples
    {
        public static void Run()
        {
            ExampleClass ec = new ExampleClass();

            dynamic result = ec.ExampleMethod(2);
            Console.WriteLine(result);

            result = ec.ExampleMethod("String");
            Console.WriteLine(result);

            // This does not work correctly as pressing Enter changes the type from int to String
            Console.WriteLine("Enter the variable you want to evaluate: ");
            dynamic dynamicVar = Console.Read();
            ec.ExampleMethod(dynamicVar);
            Console.WriteLine(result);
        }

        class ExampleClass
        {
            public dynamic ExampleMethod(dynamic d)
            {
                if (d is int)
                {
                    return "The variable is of type integer";
                }
                else
                {
                    return "The variable is not of type integer";
                }
            }
        }
    }
}
