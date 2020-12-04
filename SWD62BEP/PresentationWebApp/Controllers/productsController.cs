using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationWebApp.Controllers
{
    public class productsController : Controller
    {

        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private IHostingEnvironment _env;

        public productsController(IProductsService productsService, ICategoriesService categoriesService, IHostingEnvironment env) 
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
        }
        public IActionResult Index()
        {
            var list = _productsService.GetProducts();
           
            return View(list);
        }

        public IActionResult Details(Guid id) 
        {
            var p =_productsService.GetProduct(id);
            return View(p);
        }

        //The  engine will load a page with empthy fields
        [HttpGet]
        public IActionResult Create()
        {
            var lisOfCategories = _categoriesService.GetCategories();

            ViewBag.Categories = lisOfCategories;

            return View();
        }

        public IActionResult Delete(Guid id) 
        {
            try
            {
                _productsService.DeleteProduct(id);
                TempData["feedback"] = "product was deleted";
            }
            catch (Exception ex) 
            {
                TempData["warning"] = "prduct was not deleted";
            }
            
            return RedirectToAction("index");
        }

        //Here details input by the users will be received
        [HttpPost]
        public IActionResult Create(ProductViewModel data, IFormFile f)
        {
            try
            {
                if(f != null){
                    if (f.Length > 0)
                    {
                        string newFileName = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newFileNameWithAbsolutePath = _env.WebRootPath + @"\Images\" + newFileName;

                        using (var stream = System.IO.File.Create(newFileNameWithAbsolutePath)) 
                        {

                            f.CopyTo(stream);

                        }

                        data.Imageurl = @"\Images\" + newFileName;

                    }
                }
                _productsService.AddProduct(data);

                ViewData["feedback"] = "product was added successfully";
            }
            catch (Exception ex)
            {

                ViewData["warning"] = "product was not added";
            }

            var listOfCategories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategories;
            return View(data);
        }

    }
}
