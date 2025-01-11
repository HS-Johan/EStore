using Microsoft.AspNetCore.Mvc;

namespace EStore.Areas.EStore.Controllers
{
    [Area("EStore")]
    [Route("EStore/[Controller]/[Action]")]
    [Route("EStore/[Controller]")]

    public class EStoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
