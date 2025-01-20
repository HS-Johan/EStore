using Estore.Helper;
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
            var product = _context.Product.FirstOrDefault( x => x.ProductId == productId );

            if( product == null )
            {
                return Json(new { success = false, msg = "Product not found" } );
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId); 

            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, msg = "Product added to cart" });
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            int count = cart.Sum( x=>x.Quantity );

            return Json(count);
        }

    }
}
