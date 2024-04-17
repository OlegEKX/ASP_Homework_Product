using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data;
using System.Runtime.CompilerServices;

namespace ASP_Homework_Product.Views.Shared.ViewComponents.BasketViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IBasketStorage basketStorage;
        private readonly IConstants constants;

        public BasketViewComponent(IBasketStorage basketStorage, IConstants constants)
        {
            this.basketStorage = basketStorage;
            this.constants = constants;
        }




        /*метод будет вызываться тогда, когда нужно будет получить
        количество элементов в корзине*/
        public IViewComponentResult Invoke()
        {
            var basket = basketStorage.TryGetByUserId(constants.UserId);
            var productCounts = basket?.Amount/* ?? 0*/;
            /*if (productCounts == null)
            {
                return View("Basket", null);
            }
            else
            {
                return View("Basket", productCounts);
            }*/
            return View("Basket", productCounts);
        }
    }
}
