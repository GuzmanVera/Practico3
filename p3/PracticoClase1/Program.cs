// See https://aka.ms/new-console-template for more information
using Shared;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using BusinessLayer.IBLs;
using BusinessLayer.BLs;
using PracticoClase1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Primera Aplicación con .NET");

IDAL_Personas _personas = new DAL_Personas_EF(new DataAccessLayer.DBContextCore());
IBL_Personas _personasBL = new BL_Personas(_personas);
Commands commands = new Commands(_personasBL);

IDAL_Vehiculos _vehiculos = new DAL_Vehiculos_EF(new DataAccessLayer.DBContextCore());
IBL_Vehiculos _vehiculosBL = new BL_Vehiculos(_vehiculos); // Asume que tienes esto implementado
VehiculoCommands vehiculoCommands = new VehiculoCommands(_vehiculosBL); // Nueva instancia de VehiculoCommands

UpdateDatabase();

Console.WriteLine("Comandos Posibles:");
Console.WriteLine("1 - Agregar Persona");
Console.WriteLine("2 - Listar Personas");
Console.WriteLine("3 - Eliminar Persona");
Console.WriteLine("4 - Agregar Vehículo");
Console.WriteLine("5 - Listar Vehículos");
Console.WriteLine("6 - Eliminar Vehículo");
Console.WriteLine("7 - Salir");

Console.Write("Ingrese Comando> ");
string command = Console.ReadLine();

while(command != "7")
{
    try
    {
        switch (command)
        {
            case "1":
                commands.AddPersona();
                break;
            case "2":
                commands.ListPersonas();
                break;
            case "3":
                commands.RemovePersona();
                break;
            case "4":
                vehiculoCommands.AddVehiculo();
                break;
            case "5":
                vehiculoCommands.ListVehiculos();
                break;
            case "6":
                vehiculoCommands.RemoveVehiculo();
                break;
            default:
                Console.WriteLine("Comando no reconocido");
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("ERROR> " + ex.Message);
    }
    finally
    {
        Console.Write("Ingrese Comando> ");
        command = Console.ReadLine();
    }
}

Console.WriteLine("Gracias por usar la aplicación");

void UpdateDatabase()
{
    using (var context = new DataAccessLayer.DBContextCore())
    {
        context?.Database.Migrate();
    }
}