using Newtonsoft.Json;

namespace RickAndMortyApp.Services
{
    public class EpisodeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "https://rickandmortyapi.com/api/episode";

        public EpisodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Asenkron olarak bölüm bilgileri
        public async Task<List<Episode>> GetEpisodesAsync()
        {
            // HTTP isteği için yetkilendirme bilgisi ekliyorum
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

            // API'den bölüm bilgilerini getiriyorum
            var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/episode");
            response.EnsureSuccessStatusCode();

            // Gelen dataları string bir değişkene atıyorum
            var content = await response.Content.ReadAsStringAsync();

            // Gelen dataları convert edip başka bir değişkende tutuyorum
            var episodes = JsonConvert.DeserializeObject<ApiResponse>(content);

            return episodes?.Results;
        }
    }

    public class ApiResponse
    {
        public List<Episode> Results { get; set; }
    }

    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string episode { get; set; }
        public string created { get; set; }
        public string url { get; set; }

    }
}

