using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EStore.Controllers
{
    public class LookUpController : Controller
    {
        public IActionResult LookUpForm()
        {
            ViewBag.LookUpType = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Option 1" },
            new SelectListItem { Value = "2", Text = "Option 2" },
            new SelectListItem { Value = "3", Text = "Option 3" },
            new SelectListItem { Value = "4", Text = "Option 4" },
            new SelectListItem { Value = "5", Text = "Option 5" },
            new SelectListItem { Value = "6", Text = "Option 6" },
            new SelectListItem { Value = "7", Text = "Option 7" },
            new SelectListItem { Value = "8", Text = "Option 8" }
        };

            return View();
        }
        public IActionResult LookUpList()
        {
            return View();
        }
    }
}
