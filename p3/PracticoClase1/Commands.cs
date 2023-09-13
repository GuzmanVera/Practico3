using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;


        public Commands(IBL_Personas personasBL)
        {
            _personasBL = personasBL;
        }

        public void AddPersona()
        {
            // Pedimos los datos de la persona.
            Persona persona = new Persona();
            Console.WriteLine("Ingrese el nombre de la persona: ");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el documento de la persona: ");
            persona.Documento = Console.ReadLine();
            Console.WriteLine("Ingrese los apellidos de la persona: ");
            persona.Apellidos = Console.ReadLine();
            Console.WriteLine("Ingrese el teléfono de la persona: ");
            persona.Telefono = int.Parse(Console.ReadLine()); // Asegúrate de validar la entrada
            Console.WriteLine("Ingrese la dirección de la persona: ");
            persona.Direccion = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de nacimiento de la persona (yyyy-MM-dd): ");
            persona.FechaNacimiento = DateTime.Parse(Console.ReadLine()); // Asegúrate de validar la entrada

            _personasBL.Insert(persona);

            // Aquí asumo que tienes una función Print() en tu clase Persona para mostrar los detalles.
            // Si no la tienes, podrías simplemente usar Console.WriteLine para mostrar los detalles.
            _personasBL.Get(persona.Documento).Print();
        }


        public void ListPersonas()
        {
            List<Persona> personas = _personasBL.Get();

            Console.WriteLine("Listado de personas:");
            Console.WriteLine("| Documento | Nombre |");

            foreach (Persona persona in personas)
            {
                persona.PrintTable();
            }
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);

            Console.WriteLine("Persona eliminada correctamente.");
        }
    }


}
