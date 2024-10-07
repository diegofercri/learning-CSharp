using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class StructExamples
    {
        public struct Person
        {
            int age;
            String firstName;
            String lastName;
            float height;

            public Person()
            {
                age = 0;
                firstName = "";
                lastName = "";
                height = 0;
            }

            public Person(int age_p, String firstName_p, String lastName_p, float height_p)
            {
                this.age = age_p;
                this.firstName = firstName_p;
                this.lastName = lastName_p;
                this.height = height_p;
            }

            public int GetAge() { return age; }
            public String GetFirstName() { return firstName; }
            public String GetLastName() { return lastName; }
            public float GetHeight() { return height; }

            private void SetAge(int age_p) { this.age = age_p; }
            private void SetFirstName(String firstName_p) { this.firstName = firstName_p; }
            private void SetLastName(String lastName_p) { this.lastName = lastName_p; }
            private void SetHeight(float height_p) { this.height = height_p; }

        }

        public static void Run()
        {
            Person diego = new Person();
            Person diego2 = new Person(21, "Diego", "Fernandez", 1.80f);

            Console.WriteLine(diego2.GetFirstName() + " " + diego2.GetLastName() + " is " + diego2.GetAge() + " years old and is " + diego2.GetHeight() + " meters tall");
        }
    }
}
