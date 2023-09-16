using FilmmakerWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FilmmakerWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilmmakingDbContext _context;
 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
                                FilmmakingDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        // Action for listing scripts
        public async Task<IActionResult> Scripts()
        {
            var scripts = await _context.Scripts.ToListAsync();
            return View(scripts);
        }

        // Action for listing techniques
        public async Task<IActionResult> Techniques()
        {
            var techniques = await _context.Techniques.ToListAsync();
            return View(techniques);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}