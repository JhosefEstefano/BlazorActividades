namespace ActividadesBlazor.Models
{
    public class MailToModel
    {
        public string mailDestino { get; set; } = string.Empty;
        public string subject { get; set; } = string.Empty;
        public string htmlBody { get; set; } = string.Empty;
    }

    public class MailToResponse
    {
        public string html { get; set; } = string.Empty; 
    }
}
