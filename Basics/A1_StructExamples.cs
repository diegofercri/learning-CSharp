using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class StructExamples
    {
        public struct Persona
        {
            int edad;
            String nombre;
            String apellido;
            float altura;

            public Persona()
            {
                edad = 0;
                nombre = "";
                apellido = "";
                altura = 0;
            }

            public Persona(int edad_p, String nombre_p, String apellido_p, float altura_p)
            {
                this.edad = edad_p;
                this.nombre = nombre_p;
                this.apellido = apellido_p;
                this.altura = altura_p;
            }

            public int getEdad() { return edad; }
            public String getNombre() { return nombre; }
            public String getApellido() { return apellido; }
            public float getAltura() { return altura; }

            private void setEdad(int edad_p) { this.edad = edad_p; }
            private void setNombre(String nombre_p) { this.nombre = nombre_p; }
            private void setApellido(String apellido_p) { this.apellido = apellido_p; }
            private void setAltura(float altura_p) { this.altura = altura_p; }

        }

        private static void Main(String[] args)
        {
            Persona diego = new Persona();
            Persona diego2 = new Persona(21, "Diego", "Fernandez", 1.80f);

            Console.WriteLine(diego2.getNombre() + " " + diego2.getApellido() + " tiene " + diego2.getEdad() + " y mide " + diego2.getAltura() + " metros");
        }
    }
}
