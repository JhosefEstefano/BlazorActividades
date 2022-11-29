using ActividadesBlazor.Models;

namespace ActividadesBlazor.Services
{
    public interface IClasificacionService
    {
        Task<List<ClasificacionClienteModel>> GetClasificacion();
        Task<List<ClientesModel>> PostConsulta(ClasificacionFiltroModel obj);

    }
}
