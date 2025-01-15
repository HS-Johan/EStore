using EStore.Data;
using EStore.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EStore.Controllers
{
    public class LookUpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LookUpController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult LookUpForm()
        {
            ViewBag.LookUpType = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Support Email" },
                new SelectListItem { Value = "2", Text = "Support Phone" },
                new SelectListItem { Value = "3", Text = "Copyright" },
                new SelectListItem { Value = "4", Text = "Template By" },
                new SelectListItem { Value = "5", Text = "Address" },
                new SelectListItem { Value = "6", Text = "Email" },
                new SelectListItem { Value = "7", Text = "Phone" },
                new SelectListItem { Value = "8", Text = "Social" }
            };

            return View();
        }

        [HttpPost]
        public IActionResult LookUpSubmit( LookUp lookupmodel )
        {
            _context.LookUp.Add(lookupmodel);
            _context.SaveChanges();

            return RedirectToAction("LookUpList");
        }

        public IActionResult LookUpList()
        {
            var lookupdata = _context.LookUp.ToList();

            return View(lookupdata);
        }

        public IActionResult LookUpEdit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var data = _context.LookUp.FirstOrDefault(x => x.LookUpId == id);

            ViewBag.LookUpType = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Support Email" },
                new SelectListItem { Value = "2", Text = "Support Phone" },
                new SelectListItem { Value = "3", Text = "Copyright" },
                new SelectListItem { Value = "4", Text = "Template By" },
                new SelectListItem { Value = "5", Text = "Address" },
                new SelectListItem { Value = "6", Text = "Email" },
                new SelectListItem { Value = "7", Text = "Phone" },
                new SelectListItem { Value = "8", Text = "Social" }
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult LookUpEdit(LookUp datamodel)
        {
            _context.LookUp.Update(datamodel);
            _context.SaveChanges();

            return RedirectToAction("LookUpList");
        }

        public IActionResult LookUpDelete(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _context.LookUp.FirstOrDefault( x => x.LookUpId == id );

            if (data == null)
            {
                return NotFound();
            }

            _context.LookUp.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("LookUpList"); 
        }
    }
}
