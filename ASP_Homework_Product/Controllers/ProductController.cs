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
            ProductEdit editProduct = new ProductEdit(product.Name, product.Cost, product.Description, product.ImageURL, product.Id);

			return View(editProduct);
		}

		[HttpPost]
		public IActionResult Edit(ProductEdit productEdit, int id)
		{
            /*if (productEdit.Name == productEdit.Description)
            {
                ModelState.AddModelError("", "Название и описание не должны совпадать");
            }*/

            if (ModelState.IsValid)
            {
				var product = productStorage.TryGetById(id);

				product.Name = productEdit.Name;
				product.Cost = productEdit.Cost;
				product.Description = productEdit.Description;
				product.ImageURL = productEdit.ImageURL;

				return RedirectToAction("Products", "Administrator");
			}
            return RedirectToAction("Edit");
		}

        public IActionResult Add()
        {
            ProductEdit productEdit = new ProductEdit();
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductEdit newProduct)
        {
            if (ModelState.IsValid)
            {
				List<Product> products = productStorage.GetProducts();
				products.Add(new Product(newProduct.Name, newProduct.Cost, newProduct.Description, newProduct.ImageURL));
				return RedirectToAction("Products", "Administrator");
			}
            return RedirectToAction("Add");
        }
	}
}
