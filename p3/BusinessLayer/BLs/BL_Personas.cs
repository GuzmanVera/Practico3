using BusinessLayer.IBLs;
using DataAccessLayer.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLs
{
    public class BL_Personas : IBL_Personas
    {
        private IDAL_Personas _personas;

        public BL_Personas(IDAL_Personas personas)
        {
            _personas = personas;
        }

        public List<Persona> Get()
        {
            return _personas.Get();
        }

        public Persona Get(string documento)
        {
            return _personas.Get(documento);
        }

        public void Insert(Persona persona)
        {
            _personas.Insert(persona);
        }

        public void Update(Persona persona)
        {
            _personas.Update(persona);
        }

        public void Delete(string documento)
        {
            _personas.Delete(documento);
        }
    }
}
