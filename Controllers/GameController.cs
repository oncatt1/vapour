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

        public GameController(IGameService service) { _service = service; }

        public async Task<IActionResult> Index(string name, string genre, string platform, float? minPrice, float? maxPrice, string sort)
        {
            var games = await _service.GetAllGames();

            var genres = games.Select(g => g.Genre).Distinct().ToList();
            var platforms = games.Select(g => g.Platform).Distinct().ToList();

            ViewBag.Name = name;
            ViewBag.CurrentGenre = genre;
            ViewBag.CurrentPlatform = platform;
            ViewBag.MinPrice = minPrice?.ToString() ?? "";
            ViewBag.MaxPrice = maxPrice?.ToString() ?? "";
            ViewBag.Sort = sort;

            ViewBag.Genres = new SelectList(genres, genre);
            ViewBag.Platforms = new SelectList(platforms, platform);

            var filteredGames = await _service.GetFilteredGamesAsync(name, genre, platform, minPrice, maxPrice);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "name":
                        filteredGames = filteredGames.OrderBy(g => g.Name).ToList();
                        break;
                    case "releasedate":
                        filteredGames = filteredGames.OrderBy(g => g.Release_Date).ToList();
                        break;
                    case "lowestprice":
                        filteredGames = filteredGames.OrderBy(g => g.Price).ToList();
                        break;
                    case "highestprice":
                        filteredGames = filteredGames.OrderByDescending(g => g.Price).ToList();
                        break;
                    default:
                        break;
                }
            }

            return View(filteredGames);
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
            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> EditGame(Game game)
        {
            await _service.UpdateGame(game);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _service.DeleteGame(id);
            return RedirectToAction("Index");
        }
    }
}
