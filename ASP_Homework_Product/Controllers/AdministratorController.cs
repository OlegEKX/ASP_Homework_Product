using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class AdministratorController : Controller
    {

        private readonly IProductStorage productStorage;

        public AdministratorController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }


        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = productStorage.GetProducts();
            return View(products);
        }
    }
}
