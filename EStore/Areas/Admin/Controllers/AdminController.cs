﻿using EStore.Areas.Admin.DataModel;
using EStore.Areas.Admin.ViewModel;
using EStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.DataClassification;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
            RealDataModel.LableId = product.LableId;
            RealDataModel.IsActive = product.IsActive;


            _context.Product.Add(RealDataModel);
            _context.SaveChanges();

            //return View(product);
            return RedirectToAction("ProductForm");

        }

        public  IActionResult ProductList()
        {
            var data = _context.Product.ToList();

            return View(data);
        }

        public  IActionResult ProductEdit()
        {
            return Ok();
        }

        public  IActionResult ProductDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Product.FirstOrDefault(johan => johan.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }

        //public IActionResult ProductListByJoinQuery() //with Join Query
        //{
        //    List<Product> Products = new List<Product>();
        //    List<Label> Labels = new List<Label>();

        //    var datalist = from Product in Products
        //                   join Label in Labels
        //                   on Product.LableId equals Label.LableId
        //                   select new ProductVM
        //                   {
        //                       ProductId = Product.ProductId,
        //                       Name = Product.Name,
        //                       Description = Product.Description,
        //                       Image = Product.Image,
        //                       Price = Product.Price,
        //                       LableId = Product.LableId,
        //                       LableName = Label.LabelName,
        //                       IsActive = Product.IsActive,
        //                       Category = Product.Category,
        //                   };

        //    return View();
        //}


        //public IActionResult ProductListByMapping() //with data mapping
        //{

        //    var data = _context.Product.ToList();
        //    var Label = _context.Label.ToList();

        //    ProductVM ProductVM = new ProductVM();

        //    foreach (var prolist in data)
        //    {
        //        ProductVM.ProductId = prolist.ProductId;
        //        ProductVM.Name = prolist.Name;
        //        ProductVM.Description = prolist.Description;
        //        ProductVM.Image = prolist.Image;
        //        ProductVM.Price = prolist.Price;
        //        ProductVM.LableId = prolist.LableId;
        //        ProductVM.LableName = Label.FirstOrDefault(x => x.LableId == prolist.LableId).ToString();
        //        ProductVM.IsActive = prolist.IsActive;
        //        ProductVM.Category = prolist.Category;
        //    }

        //    return View(ProductVM);
        //}

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
