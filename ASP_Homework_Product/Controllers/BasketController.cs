using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class BasketController : Controller
    {
        private readonly ProductStorage productStorage;

        public BasketController()
        {
            productStorage = new ProductStorage();
        }

        /// <summary>
        /// завершить добавление товара в корзину,
        /// переделть метод так, чтобы при нажатиии кнопки "добавить в корзину"
        /// обрабатывалось событие добавления товара в корзину
        /// и показ самой страницы корзины
        /// </summary>
        /// <returns></returns>
        //
        public IActionResult Index()
        {
            var products = productStorage.GetProducts();
            return View(products);
        }

        
    }
}
