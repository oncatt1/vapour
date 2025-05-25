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
    }
}
