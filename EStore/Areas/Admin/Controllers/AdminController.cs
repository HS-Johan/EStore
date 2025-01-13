using EStore.Areas.Admin.DataModel;
using EStore.Areas.Admin.ViewModel;
using EStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.DataClassification;
using System.Reflection.Emit;
using Label = EStore.Areas.Admin.DataModel.Label;

namespace EStore.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Route("Admin/[Controller]")]

    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductForm()
        {
            ViewBag.LabelList = _context.Label.Select(x => new SelectListItem
            {
                Value = x.LableId.ToString(),
                Text = x.LabelName

            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductSubmit(ProductVM product)
        {
            //file upload start
            string uniqueFileName = null;
            if (product.UploadImage != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.UploadImage.FileName;

                string filepath = Path.Combine(uploadsFolder, uniqueFileName);

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);

                }
                using (var filestrem = new FileStream(filepath, FileMode.Create))
                {
                    await product.UploadImage.CopyToAsync(filestrem);
                }

            }
            //file upload End

            var RealDataModel = new Product();

            RealDataModel.Name = product.Name;
            RealDataModel.Price = product.Price;
            RealDataModel.Description = product.Description;
            RealDataModel.Category = product.Category;
            RealDataModel.Image = uniqueFileName;


            _context.Product.Add(RealDataModel);
            _context.SaveChanges();

            return View(product);

        }

        public IActionResult Labels()
        {
            var LabelList = _context.Label.ToList();

            return View(LabelList);
        }

        public IActionResult LabelCreate(Label datamodel)
        {
            _context.Label.Add(datamodel);

            try
            {
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }

    }
}
