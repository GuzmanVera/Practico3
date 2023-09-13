using System;

namespace Shared
{
    public class Vehiculo
    {
        public string Marca { get; set; } = "-- Sin Marca --";
        public string Modelo { get; set; } = "-- Sin Modelo --";

        private string matricula = "";
        public string Matricula
        {
            get
            {
                return matricula;
            }
            set
            {
                if (value.Length >= 6)
                {
                    matricula = value;
                }
                else
                {
                    throw new Exception("El formato de la matrícula no es correcto.");
                }
            }
        }

        // Esta propiedad podría usarse para asociar el vehículo con una Persona en caso de que necesites esa funcionalidad
        public string DocumentoPropietario { get; set; } = "-- Sin Propietario --";

        public void Print()
        {
            Console.WriteLine("-- Vehiculo --");
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Matrícula: " + Matricula);
            Console.WriteLine("Documento del Propietario: " + DocumentoPropietario);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Marca + " | " + Modelo + " | " + Matricula + " | " + DocumentoPropietario + " |");
        }
    }
}
