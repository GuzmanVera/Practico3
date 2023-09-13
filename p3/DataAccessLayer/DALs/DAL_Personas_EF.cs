using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            var persona = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (persona != null)
            {
                _dbContext.Personas.Remove(persona);
                _dbContext.SaveChanges();
            }
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona
                             {
                                 Documento = p.Documento,
                                 Nombre = p.Nombres,
                                 Apellidos = p.Apellidos,
                                 Telefono = p.Telefono,
                                 Direccion = p.Direccion,
                                 FechaNacimiento = p.FechaNacimiento
                             })
                             .ToList();
        }

        public Persona Get(string documento)
        {
            var persona = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (persona != null)
            {
                return new Persona
                {
                    Documento = persona.Documento,
                    Nombre = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    Telefono = persona.Telefono,
                    Direccion = persona.Direccion,
                    FechaNacimiento = persona.FechaNacimiento
                };
            }
            return null;
        }

        public void Insert(Persona persona)
        {
            var nuevaPersona = new Personas
            {
                Documento = persona.Documento,
                Nombres = persona.Nombre,
                Apellidos = persona.Apellidos,
                Telefono = persona.Telefono,
                Direccion = persona.Direccion,
                FechaNacimiento = persona.FechaNacimiento
            };
            _dbContext.Personas.Add(nuevaPersona);
            _dbContext.SaveChanges();
        }

        public void Update(Persona persona)
        {
            var personaExistente = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.Documento);
            if (personaExistente != null)
            {
                personaExistente.Nombres = persona.Nombre;
                personaExistente.Apellidos = persona.Apellidos;
                personaExistente.Telefono = persona.Telefono;
                personaExistente.Direccion = persona.Direccion;
                personaExistente.FechaNacimiento = persona.FechaNacimiento;
                _dbContext.SaveChanges();
            }
        }
    }
}
