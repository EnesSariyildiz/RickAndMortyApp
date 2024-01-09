using Microsoft.AspNetCore.Mvc;
using RickAndMortyApp.Services;

namespace RickAndMortyApp.Controllers
{
    public class CharacterController : Controller
    {
        private readonly CharacterService _characterService;
        private readonly HttpClient _httpClient;

        public CharacterController(CharacterService characterService, HttpClient httpClient)
        {
            _characterService = characterService;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(string p)
        {
            var characters = await _characterService.GetCharactersAsync();

            if (!string.IsNullOrEmpty(p))
            {
                return View(characters.Where(c => c.Name.Contains(p) || c.Status.Contains(p) || c.Species.Contains(p)));
            }

            return View(characters);
        }

        public async Task<IActionResult> CharacterDetails(int id)
        {
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/character/{id}");
            if (response.IsSuccessStatusCode)
            {
                var characterData = await response.Content.ReadFromJsonAsync<Character>(); // Bu satırı değiştirdim
                return View(characterData);
            }
            return View("Error");
        }

        public async Task<IActionResult> FavoriteCharacters()
        {
            return View();
        }
        public async Task<IActionResult> AddToFavorites(int id)
        {
            return View();
        }

    }

}
