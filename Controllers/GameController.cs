using GameCatalog.Models;
using GameCatalog.Services;
using GameCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameCatalog.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(string genre, string platform, string priceRange)
        {
            var genres = new List<string> {
                "Action", "Action RPG", "Action-Adventure", "Arcade", "Battle Royale", "FPS", "Fighting",
                "MMORPG", "MOBA", "Metroidvania", "Party", "Platformer", "Puzzle", "RPG", "Racing", "Rhythm",
                "Roguelike", "RTS", "Sandbox", "Shooter", "Simulation", "Sports", "Stealth", "Strategy",
                "Survival horror", "Tactical RPG", "Third-Person Shooter", "Tower Defense"
        };

            var platforms = new List<string> {
                "Arcade", "Game Boy Color", "GameBoy", "GameCube", "NES", "N64", "PC", "PS2", "PS3", "PS4",
                "PlayStation", "SNES", "Switch", "Wii", "Xbox", "Xbox 360"
        };


            ViewBag.Genres = new SelectList(genres, genre);
            ViewBag.Platforms = new SelectList(platforms, platform);

            var games = await _service.GetFilteredGamesAsync(genre, platform);
            return View(games);
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

        public async Task<IActionResult> DeleteGame(int id)
        {
            await _service.DeleteGame(id);
            return RedirectToAction("Index");
        }
        

    }
}
