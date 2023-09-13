using BusinessLayer.IBLs;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using Shared;
using System.Collections.Generic;

namespace BusinessLayer.BLs
{
    public class BL_Vehiculos : IBL_Vehiculos
    {
        private IDAL_Vehiculos _dalVehiculos;

        public BL_Vehiculos(IDAL_Vehiculos dalVehiculos)
        {
            _dalVehiculos = dalVehiculos;
        }

        public void Insert(Vehiculo vehiculo, string documentoPersona)
        {
            _dalVehiculos.Insert(vehiculo, documentoPersona);
        }

        public void Delete(string matricula)
        {
            _dalVehiculos.Delete(matricula);
        }

        public List<Vehiculo> Get()
        {
            return _dalVehiculos.Get();
        }

        public Vehiculo Get(string matricula)
        {
            return _dalVehiculos.Get(matricula);
        }

        public void Update(Vehiculo vehiculo)
        {
            _dalVehiculos.Update(vehiculo);
        }
    }
}
