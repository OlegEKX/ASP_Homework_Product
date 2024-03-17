using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASP_Homework_Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductStorage productStorage;

        public ProductController()
        {
            productStorage = new ProductStorage();
        }

        public IActionResult Index(int id)
        {
            var products = productStorage.GetProducts();
            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    return View(item);
                }
            }
            return View(products);
        }
    }
}
