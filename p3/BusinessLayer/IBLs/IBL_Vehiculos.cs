using Shared;
using System.Collections.Generic;

namespace BusinessLayer.IBLs
{
    public interface IBL_Vehiculos
    {
        void Insert(Vehiculo vehiculo, string documentoPersona);
        void Delete(string matricula);
        List<Vehiculo> Get();
        Vehiculo Get(string matricula);
        void Update(Vehiculo vehiculo);
    }
}
