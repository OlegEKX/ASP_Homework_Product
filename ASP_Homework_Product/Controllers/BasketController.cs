using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly IBasketStorage basketStorage;
        private readonly IConstants constants;

        public BasketController(IProductStorage productStorage, IBasketStorage basketStorage, IConstants constants)
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
        public IActionResult Remove(int productId)
        {
            var product = productStorage.TryGetById(productId);
            basketStorage.Remove(product, constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            basketStorage.Clear(constants.UserId);
            return RedirectToAction("Index");
        }

        //думал создать дополнительный иетод для добавления товара в корзину по кнопке "+"
        /*public IActionResult Append(int productId)
        {
            var product = productStorage.TryGetById(productId);
            basketStorage.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }*/
    }
}
