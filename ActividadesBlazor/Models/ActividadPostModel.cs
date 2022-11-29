namespace ActividadesBlazor.Models
{
    public class ActividadPostModel
    {
        public int idCliente { get; set; } = 0;
        public string idClienteUsuarioConfirma { get; set; } = string.Empty;
        public int idDepartamentoAdministrativo { get; set; } = 0;
        public int idTipoActividad { get; set; } = 0;
        public int idEmpresa { get; set; } = 0;
        public int idSucursal { get; set; } = 0;
        public DateTime fecha { get; set; } = DateTime.Now;
        public HoraInicio horaInicio { get; set; } = new HoraInicio();
        public HoraFin horaFin { get; set; } = new HoraFin();
        public int horasCobrables { get; set; } = 0;
        public int horasInternas { get; set; } = 0;
        public string observacion { get; set; } = string.Empty;
        public string html { get; set; } = string.Empty;
    }

    public class ActividadPostViewModel
    {
        public int idCliente { get; set; } = 0;
        public string idClienteUsuarioConfirma { get; set; } = string.Empty;
        public int idDepartamentoAdministrativo { get; set; } = 0;
        public int idTipoActividad { get; set; } = 0;
        public int idEmpresa { get; set; } = 0;
        public int idSucursal { get; set; } = 0;
        public DateTime fecha { get; set; } = DateTime.Now;
        public DateTime horaInicio { get; set; } = DateTime.Now;
        public DateTime horaFin { get; set; } = DateTime.Now;
        public int horasCobrables { get; set; } = 0;
        public int horasInternas { get; set; } = 0;
        public string observacion { get; set; } = string.Empty;
        public string html { get; set; } = string.Empty;
    }

    public class HoraInicio
    {
        public int horas { get; set; } = 0;
        public int minutos { get; set; } = 0; 
    }
    public class HoraFin
    {
        public int horas { get; set; } = 0;
        public int minutos { get; set; } = 0;
    }
}
