using GameCatalog.Models;
using GameCatalog.Services;
using GameCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string name, string genre, string platform, float? minPrice, float? maxPrice)
        {
            // Pobierz wszystkie gry, ¿eby wyci¹gn¹æ listê unikalnych gatunków i platform
            var games = await _service.GetAllGames();

            var genres = games.Select(g => g.Genre).Distinct().ToList();
            var platforms = games.Select(g => g.Platform).Distinct().ToList();

            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Name = "";
                name = null; // ¿eby filtr nie dzia³a³ na pust¹ nazwê
            }
            else
            {
                ViewBag.Name = name;
            }

            ViewBag.CurrentGenre = genre;
            ViewBag.CurrentPlatform = platform;

            ViewBag.Genres = new SelectList(genres, genre);
            ViewBag.Platforms = new SelectList(platforms, platform);

            ViewBag.MinPrice = minPrice?.ToString() ?? "";
            ViewBag.MaxPrice = maxPrice?.ToString() ?? "";

            var gameslist = await _service.GetFilteredGamesAsync(name, genre, platform, minPrice, maxPrice);
            return View(gameslist);
        }





        public IActionResult AddGame()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGame(Game game)
        {
            await _service.AddGame(game);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditGame(int id)
        {

            var game = await _service.GetGameById(id);
            if (game == null)
                return NotFound();

            return View(game);

        }
        [HttpPost]
        public async Task<IActionResult> EditGame(Game game)
        {
            await _service.UpdateGame(game);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SearchByName(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) { return RedirectToAction("Index"); }
            var filteredGames = await _service.SearchGamesByNameAsync(searchTerm);
            ViewBag.SearchTerm = searchTerm; 
            return View("Index", filteredGames); 
        }
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _service.DeleteGame(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SortGamesAsync(string sortBy, bool ascending = true)
        {
            var games = await _service.SortGamesAsync(sortBy, ascending);
            return Ok(games);
        }

    }
}
