using ActividadesBlazor.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json;

namespace ActividadesBlazor.Services
{
    public class ActividadService : IActividadService
    {
        private readonly HttpClient _httpClient;
        const string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqaG9zZWYucmV5ZXNAc2l0ZWNhLm5ldCIsImp0aSI6ImE5NmIyZjI2LWJjM2YtNDJjYy1iMDhlLTJiNWI5Yjc2YWI1MyIsIlVzdWFyaW8iOiJqaG9zZWYucmV5ZXNAc2l0ZWNhLm5ldCIsImV4cCI6MTY2OTY5Mjk3M30.Lnjl1L1k6u1rSj_TPJAOmI6NunFFyFA6s4-IwDgBaJA";

        public ActividadService(HttpClient http)
        {
            this._httpClient = http;
        }

        public async Task<List<DepartamentoModel>> GetDeparamentos()
        {
            ConfigureHttpClient();
            var response = await _httpClient.GetAsync($"DepartamentoAdministrativo");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            List<DepartamentoModel> lLista = new List<DepartamentoModel>();

            lLista = await JsonSerializer.DeserializeAsync<List<DepartamentoModel>>(stream);

            return lLista;
        }

        public async Task<List<EmpresaModel>> GetEmpresas(int pIdCliente)
        {
            ConfigureHttpClient();
            var response = await _httpClient.GetAsync($"Empresa/{pIdCliente}");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            List<EmpresaModel> lLista = new List<EmpresaModel>();

            lLista = await JsonSerializer.DeserializeAsync<List<EmpresaModel>>(stream);

            return lLista;
        }

        public async Task<List<SucursalModel>> GetSucursales(int pIdEmpresa)
        {
            ConfigureHttpClient();
            var response = await _httpClient.GetAsync($"EmpresaSucursal/{pIdEmpresa}");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            List<SucursalModel> lLista = new List<SucursalModel>();

            lLista = await JsonSerializer.DeserializeAsync<List<SucursalModel>>(stream);

            return lLista; ;
        }

        public async Task<List<TipoActividadModel>> GetTiposActividad(int pIdGrupoActividad)
        {
            ConfigureHttpClient();
            var response = await _httpClient.GetAsync($"TipoActividad/{pIdGrupoActividad}");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            List<TipoActividadModel> lLista = new List<TipoActividadModel>();

            lLista = await JsonSerializer.DeserializeAsync<List<TipoActividadModel>>(stream);

            return lLista;
        }

        public async Task<List<UsuarioModel>> GetUsuarios(int pIdCliente)
        {

            ConfigureHttpClient();

            var response = await _httpClient.GetAsync($"ClienteUsuario/{pIdCliente}");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            List<UsuarioModel> lLista = new List<UsuarioModel>();

            lLista = await JsonSerializer.DeserializeAsync<List<UsuarioModel>>(stream);

            return lLista;
        }

        public async Task<List<GrupoActividadModel>> GruposActividad()
        {
            var response = await _httpClient.GetAsync($"GrupoActividad");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            List<GrupoActividadModel> lLista = new List<GrupoActividadModel>();

            lLista = await JsonSerializer.DeserializeAsync<List<GrupoActividadModel>>(stream);

            return lLista;
        }

        public async Task<ActividadResponseModel> PostCrearActividad(ActividadPostModel pObj)
        {

            var response = await _httpClient.PostAsJsonAsync("Actividad", pObj);

            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            ActividadResponseModel Ob = new ActividadResponseModel();
            Ob = await JsonSerializer.DeserializeAsync<ActividadResponseModel>(stream);

            MailToModel Mail = new MailToModel()
            {
                htmlBody = Ob.cuerpoHtml,
                subject = Ob.asunto,
                mailDestino = Ob.mailDestinatario
            };

            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("https://irxcr2fa6l.execute-api.us-west-2.amazonaws.com/Prod/api/");

            var emailResponse = await http.PostAsJsonAsync("SES/ActividadSoporte", Mail);

            return Ob;
        }

        private void ConfigureHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        }
    }
}
