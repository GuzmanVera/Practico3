using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.DALs
{
    public class VehiculoRepository : IDAL_Vehiculos
    {
        private readonly DBContextCore _dbContext;

        public VehiculoRepository(DBContextCore dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Vehiculo> Get()
        {
            return _dbContext.Vehiculos
                .Select(v => MapToVehiculo(v))
                .ToList();
        }

        public Vehiculo Get(string matricula)
        {
            var vehiculo = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
            return vehiculo != null ? MapToVehiculo(vehiculo) : null;
        }

        public void Insert(Vehiculo vehiculo, string documentoPersona)
        {
            var persona = _dbContext.Personas.FirstOrDefault(p => p.Documento == documentoPersona);
            if (persona == null)
            {
                throw new InvalidOperationException("La persona con el documento especificado no existe.");
            }

            var nuevoVehiculo = new Vehiculos
            {
                Matricula = vehiculo.Matricula,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Persona = persona
            };

            _dbContext.Vehiculos.Add(nuevoVehiculo);
            _dbContext.SaveChanges();
        }

        public void Update(Vehiculo vehiculo)
        {
            var vehiculoExistente = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == vehiculo.Matricula);
            if (vehiculoExistente != null)
            {
                vehiculoExistente.Marca = vehiculo.Marca;
                vehiculoExistente.Modelo = vehiculo.Modelo;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(string matricula)
        {
            var vehiculo = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
            if (vehiculo != null)
            {
                _dbContext.Vehiculos.Remove(vehiculo);
                _dbContext.SaveChanges();
            }
        }

        private Vehiculo MapToVehiculo(Vehiculos vehiculoEntity)
        {
            return new Vehiculo
            {
                Matricula = vehiculoEntity.Matricula,
                Marca = vehiculoEntity.Marca,
                Modelo = vehiculoEntity.Modelo
                // Puedes añadir más campos aquí
            };
        }
    }
}
