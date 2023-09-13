using DataAccessLayer.EFModels;
using Shared;

namespace DataAccessLayer.IDALs
{
    public interface IDAL_Vehiculos
    {
        void Delete(string matricula);
        List<Vehiculo> Get();
        Vehiculo Get(string matricula);
        void Insert(Vehiculo vehiculo, string documentoPersona);
        void Update(Vehiculo vehiculo);
    }
}
