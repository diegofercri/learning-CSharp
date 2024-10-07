using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class CollectionsExamples
    {
        public static void Run()
        {
            List<String> myList = new List<String>();

            String input = new String("");
            while (!input.Equals("END"))
            {
                Console.WriteLine("Enter the next value in the string (END to finish): ");
                input = Console.ReadLine();
                myList.Add(input);
            }

            Console.WriteLine("Enter the value from the list you want to remove: ");
            input = Console.ReadLine();
            if (myList.Contains(input))
            {
                myList.Remove(input);
            }
            else
            {
                Console.WriteLine("Sorry, that value does not exist");
            }

            foreach (String str in myList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
