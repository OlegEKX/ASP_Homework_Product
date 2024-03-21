using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASP_Homework_Product.Controllers
{
    public class BasketController : Controller
    {
        private readonly BasketStorage productsInBasket;
        private readonly ProductStorage productStorage;

        public BasketController()
        {
            productsInBasket = new BasketStorage();
            productStorage = new ProductStorage();
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Index(int id)
        {
            var products = productStorage.GetProducts();
            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    productsInBasket.AddToBasket(item);
                    return View(item);
                }
            }


            return View(products);
        }



        /*private readonly ProductStorage productStorage;
        public BasketController()
        {
            productStorage = new ProductStorage();
        }*/

        /// <summary>
        /// завершить добавление товара в корзину,
        /// переделть метод так, чтобы при нажатиии кнопки "добавить в корзину"
        /// обрабатывалось событие добавления товара в корзину
        /// и показ самой страницы корзины
        /// </summary>
        /// <returns></returns>
        //
        /*public IActionResult Index()
        {
            var products = productStorage.GetProducts();

            return View(products[1]);
        }*/

        /*public IActionResult Index(Product product)
        {
            return View(product);
        }*/
        
    }
}
