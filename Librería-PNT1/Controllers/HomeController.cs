using libreria_PNT1.Models;
using Libreria_PNT1.Models;
using Libreria_PNT1.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria_PNT1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILibroRepository _libroRepository;

        public HomeController(ILogger<HomeController> logger, ILibroRepository libroRepository)
        {
            _logger = logger;
            _libroRepository = libroRepository;
        }

        public async Task<IActionResult> Index()
        {
            // <-- Mostrar mensaje del Checkout
            ViewBag.CheckoutMessage = TempData["CheckoutMessage"] as string;

            var novedades = (await _libroRepository.GetAllAsync())
                                .Take(4)
                                .ToList();

            return View(novedades);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
