using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using Shared;
using System;
using System.Collections.Generic;

namespace PracticoClase1
{
    public class VehiculoCommands
    {
        private readonly IBL_Vehiculos _vehiculosBL;

        public VehiculoCommands(IBL_Vehiculos vehiculosBL)
        {
            _vehiculosBL = vehiculosBL ?? throw new ArgumentNullException(nameof(vehiculosBL));
        }

        public void AddVehiculo()
        {
            var vehiculo = GetVehiculoFromUserInput();

            _vehiculosBL.Insert(vehiculo, vehiculo.DocumentoPropietario);

            PrintVehiculoDetails(_vehiculosBL.Get(vehiculo.Matricula));
        }

        public void ListVehiculos()
        {
            var vehiculos = _vehiculosBL.Get();

            Console.WriteLine("Listado de vehículos:");
            Console.WriteLine("| Marca | Modelo | Matrícula | Propietario |");

            foreach (var vehiculo in vehiculos)
            {
                vehiculo.PrintTable();
            }
        }

        public void RemoveVehiculo()
        {
            Console.WriteLine("Ingrese la matrícula del vehículo a eliminar: ");
            string matricula = Console.ReadLine();

            _vehiculosBL.Delete(matricula);

            Console.WriteLine("Vehículo eliminado correctamente.");
        }

        private Vehiculo GetVehiculoFromUserInput()
        {
            var vehiculo = new Vehiculo();
            Console.WriteLine("Ingrese la marca del vehículo: ");
            vehiculo.Marca = Console.ReadLine();
            Console.WriteLine("Ingrese el modelo del vehículo: ");
            vehiculo.Modelo = Console.ReadLine();
            Console.WriteLine("Ingrese la matrícula del vehículo: ");
            vehiculo.Matricula = Console.ReadLine();
            Console.WriteLine("Ingrese el documento del propietario del vehículo: ");
            vehiculo.DocumentoPropietario = Console.ReadLine();
            return vehiculo;
        }

        private void PrintVehiculoDetails(Vehiculo vehiculo)
        {
            Console.WriteLine("Detalles del vehículo:");
            vehiculo.Print();
        }
    }
}
