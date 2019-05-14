using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(newProduct);
                return RedirectToAction("Index");
            }

            return View(newProduct);

        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            if (id?.Length == 0) return BadRequest();

            var product = _productService.Get(id);

            if (product == null)
            {
                TempData["error"] = "Unable to find requested data...";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id?.Length == 0) return BadRequest();

            _productService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}