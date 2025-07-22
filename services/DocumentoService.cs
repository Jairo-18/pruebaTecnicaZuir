using System.Net.Http.Headers;
using System.Net.Http.Json;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public class DocumentoService
    {
        private readonly HttpClient _http;

        public DocumentoService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://mainserver.ziursoftware.com/Ziur.API/basedatos_01/");
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "ae8bad44-7348-11ee-b962-0242ac120002");
        }

        public async Task<List<DocumentoModel>> GetDocumentosAsync()
        {
            var response = await _http.GetFromJsonAsync<List<DocumentoModel>>("ZiurServiceRest.svc/api/DocumentosFillsCombos");
            return response ?? new List<DocumentoModel>();
        }
    }
}
