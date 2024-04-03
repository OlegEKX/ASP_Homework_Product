using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductStorage productStorage;

        public ProductController(ProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index(int id)
        {
            
            Product product = productStorage.TryGetById(id);
            return View(product);
        }
    }
}
