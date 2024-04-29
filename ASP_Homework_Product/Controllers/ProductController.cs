using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ASP_Homework_Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;

        public ProductController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index(int id)
        {

            Product product = productStorage.TryGetById(id);
            return View(product);
        }

        public IActionResult Del(int id)
        {
            productStorage.Del(id);
            return RedirectToAction("Products", "Administrator");
        }

        
		public IActionResult Edit(int id)
		{
            var product = productStorage.TryGetById(id);

			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(ProductEdit productEdit, int id)
		{
			var product = productStorage.TryGetById(id);

			product.Name = productEdit.Name;
			product.Cost = productEdit.Cost;
			product.Description = productEdit.Description;
			product.ImageURL = productEdit.ImageURL;

			return RedirectToAction("Products", "Administrator");
		}

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductEdit newProduct)
        {
            List<Product> products = productStorage.GetProducts();
            products.Add(new Product(newProduct.Name, newProduct.Cost, newProduct.Description, newProduct.ImageURL));
            return RedirectToAction("Products","Administrator");
        }
	}
}
