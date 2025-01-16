using EStore.Data;
using EStore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Controllers
{
    public class EStoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EStoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allproducts = _context.Product.Take(10).ToList();

            var viewmodel = new HomePageVM();

            viewmodel.Product = allproducts;

            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] int productId)
        {
            return Ok();
        }
    }
}
