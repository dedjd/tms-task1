using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using TmsMvc.Models;
using TmsMvc.Services;

namespace TmsMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IInventoryService _service;

        public HomeController(ILogger<HomeController> logger, IInventoryService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult ListProducts()
        {
            ProductListModel productList = _service.GetProducts();

            return View(productList);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                CommandResultModel result = _service.AddProduct(product);

                if (result.Success)
                {
                    return RedirectToAction("ListProducts");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
            }

            return View(product);
        }

        public IActionResult EditProduct(Guid id)
        {
            ProductModel product = _service.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductModel updatedProduct)
        {
            if (ModelState.IsValid)
            {
                CommandResultModel result = _service.UpdateProduct(updatedProduct);

                if (result.Success)
                {
                    return RedirectToAction("ListProducts");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
            }

            return View("ListProducts", updatedProduct);
        }

        [HttpPost]
        public IActionResult DeleteProduct(SelectProductModel selectedProduct)
        {
            CommandResultModel result = _service.DeleteProduct(selectedProduct);

            if (result.Success)
            {
                return RedirectToAction("ListProducts");
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}