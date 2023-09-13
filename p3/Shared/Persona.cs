using System;

namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; } = "-- Sin Nombre --";
        public string Apellidos { get; set; } = "-- Sin Apellidos --";
        public int Telefono { get; set; }
        public string Direccion { get; set; } = "-- Sin Dirección --";
        public DateTime FechaNacimiento { get; set; }

        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length >= 7)
                {
                    documento = value;
                }
                else
                {
                    throw new Exception("El formato del documento no es correcto.");
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Documento: " + Documento);
            Console.WriteLine("Teléfono: " + Telefono);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Fecha de Nacimiento: " + FechaNacimiento.ToShortDateString());
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Documento + " | " + Nombre + " | " + Apellidos + " | " + Telefono + " | " + Direccion + " | " + FechaNacimiento.ToShortDateString() + " |");
        }
    }
}
