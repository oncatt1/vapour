using Microsoft.AspNetCore.Mvc;

namespace KatalogGier.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
