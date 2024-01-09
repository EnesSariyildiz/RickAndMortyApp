using Newtonsoft.Json;

namespace RickAndMortyApp.Services
{
    public class CharacterService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "https://rickandmortyapi.com/api/character";

        public CharacterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

            var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/character");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var characters = JsonConvert.DeserializeObject<CharacterApiResponse>(content);

            return characters?.Results;
        }
    }

    public class CharacterApiResponse
    {
        public List<Character> Results { get; set; }
    }

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public string Created { get; set; }
        public string Url { get; set; }

        [JsonProperty("image")] // Json'dan gelen veriyi eşleştirmek için
        public string Image { get; set; }
    }
}

