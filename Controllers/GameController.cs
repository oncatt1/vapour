using GameCatalog.Models;
using GameCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _service.GetAllGames();
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
           
            return View();
        }
        public async Task<IActionResult> EditGame(int id)
        {
            var games = await _service.GetAllGames();
            return View();
        }

        public async Task<IActionResult> DeleteGame(int id)
        {
            await _service.DeleteGame(id);
            return RedirectToAction("Index");
        }
    }
}
