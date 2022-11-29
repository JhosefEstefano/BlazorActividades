namespace ActividadesBlazor.Models
{
    public class ActividadResponseModel
    {
        public Guid llave { get; set; } = Guid.Empty;
        public string mailDestinatario { get; set; } = string.Empty;
        public string asunto { get; set; } = string.Empty;
        public string cuerpoHtml { get; set; } = string.Empty; 
    }
}
