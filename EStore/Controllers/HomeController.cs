using System.Diagnostics;
using EStore.Data;
using EStore.Models;
using EStore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var allproduct = _context.Product.Take(10).ToList();

            var HomePageVM = new HomePageVM();

            HomePageVM.Product = allproduct;

            return View(HomePageVM);
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
