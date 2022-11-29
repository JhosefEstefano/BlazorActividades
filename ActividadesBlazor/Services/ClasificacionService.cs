using ActividadesBlazor.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ActividadesBlazor.Services
{
    public class ClasificacionService : IClasificacionService
    {
        private readonly HttpClient _httpClient;
        const string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqaG9zZWYucmV5ZXNAc2l0ZWNhLm5ldCIsImp0aSI6ImE5NmIyZjI2LWJjM2YtNDJjYy1iMDhlLTJiNWI5Yjc2YWI1MyIsIlVzdWFyaW8iOiJqaG9zZWYucmV5ZXNAc2l0ZWNhLm5ldCIsImV4cCI6MTY2OTY5Mjk3M30.Lnjl1L1k6u1rSj_TPJAOmI6NunFFyFA6s4-IwDgBaJA";


        public ClasificacionService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<ClasificacionClienteModel>> GetClasificacion()
        {

            ConfigureHttpClient();
            var response = await _httpClient.GetAsync("ClasificacionCliente");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            var lReponse = JsonSerializer.DeserializeAsync<List<ClasificacionClienteModel>>(stream);

            return await lReponse;
        }

        public async Task<List<ClientesModel>> PostConsulta(ClasificacionFiltroModel obj)
        {

            try
            {
                var response = await  _httpClient.PostAsJsonAsync<ClasificacionFiltroModel>("Cliente/Consulta", obj);

                response.EnsureSuccessStatusCode();

                using var stream =  response.Content.ReadAsStream();

                return await JsonSerializer.DeserializeAsync<List<ClientesModel>>(stream);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private void ConfigureHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        }

    }
}
