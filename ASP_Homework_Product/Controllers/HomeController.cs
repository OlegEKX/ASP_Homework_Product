using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_Homework_Product.Models;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace ASP_Homework_Product.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly IBasketStorage basketStorage;
        private readonly IProductStorage productStorage;
        private readonly IConstants constants;

        public HomeController(IProductStorage productStorage, IBasketStorage basketStorage, IConstants constants)
        {
            this.productStorage = productStorage;
            this.basketStorage = basketStorage;
            this.constants = constants;
        }

        public IActionResult Index()
        {
            /*var basket = basketStorage.TryGetByUserId(constants.UserId);
            ViewBag.ProductCount = basket?.Amount;*/
            /*List<Product> product = ProductStorage.GetProducts();*/
            var products = productStorage.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Search(string word)
        {

            if (word != null)
            {
				List<Product> products = productStorage.GetProducts();

				var findProducts = products.Where(product => product.Name.ToLower().Contains(word.ToLower())).ToList();
                return View(findProducts);
			}
			return RedirectToAction("Index");

			/*foreach (var item in products)
            {
                if (item.Name.ToLower() == word.ToLower())
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }*/

		}
    }
}
