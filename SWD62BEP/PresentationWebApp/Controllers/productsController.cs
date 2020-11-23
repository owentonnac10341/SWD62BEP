﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;

namespace PresentationWebApp.Controllers
{
    public class productsController : Controller
    {

        private IProductsService _productsService;

        public productsController(IProductsService productsService) 
        {
            _productsService = productsService;
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

    }
}
