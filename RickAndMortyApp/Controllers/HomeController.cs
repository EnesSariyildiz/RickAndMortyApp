using Microsoft.AspNetCore.Mvc;
using RickAndMortyApp.Services;

namespace RickAndMortyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EpisodeService _episodeService;
        private readonly HttpClient _httpClient;

        public HomeController(EpisodeService episodeService, HttpClient httpClient)
        {
            _episodeService = episodeService;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(string p)
        {
            var episodes = await _episodeService.GetEpisodesAsync();

            if (!string.IsNullOrEmpty(p))
            {
                return View(episodes.Where(c => c.Name.Contains(p) || c.url.Contains(p) || c.episode.Contains(p)));
            }
            return View(episodes);
        }

        public async Task<IActionResult> EpisodeDetails(int id)
        {
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/episode/{id}");

            if (response.IsSuccessStatusCode)
            {
                var episodeData = await response.Content.ReadFromJsonAsync<Episode>(); // Bu satýrý deðiþtirdim

                return View(episodeData);
            }

            return View("Error");
        }

    }
}
