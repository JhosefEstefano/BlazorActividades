using ActividadesBlazor.Models;

namespace ActividadesBlazor.Services
{
    public interface IActividadService
    {
        Task<List<UsuarioModel>> GetUsuarios(int pIdCliente);
        Task<List<DepartamentoModel>> GetDeparamentos();
        Task<List<GrupoActividadModel>> GruposActividad();
        Task<List<TipoActividadModel>> GetTiposActividad(int pIdGrupoActividad);
        Task<List<EmpresaModel>> GetEmpresas(int pIdCliente);
        Task<List<SucursalModel>> GetSucursales(int pIdEmpresa);
        Task<ActividadResponseModel> PostCrearActividad(ActividadPostModel pObj);
    }
}
