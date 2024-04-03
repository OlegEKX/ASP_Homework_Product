using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class BasketController : Controller
    {
        private readonly ProductStorage productStorage;
        private readonly BasketStorage basketStorage;
        private readonly Constants constants;

        public BasketController(ProductStorage productStorage, BasketStorage basketStorage, Constants constants)
        {
            this.productStorage = productStorage;
            this.basketStorage = basketStorage;
            this.constants = constants;
        }

        public IActionResult Index()
        {
            var basket = basketStorage.TryGetByUserId(constants.UserId);
            return View(basket);
        }
        public IActionResult Add(int productId)
        {
            var product = productStorage.TryGetById(productId);
			basketStorage.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
