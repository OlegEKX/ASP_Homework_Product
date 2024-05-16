using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_Homework_Product.Models;
using Microsoft.VisualBasic;

namespace ASP_Homework_Product.Controllers
{
    public class AdministratorController : Controller
    {

        private readonly IProductStorage productStorage;
        private readonly IOrderStorage orderStorage;

        public AdministratorController(IProductStorage productStorage, IOrderStorage orderStorage)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            // забыл добавить зависимость для IOrderStorage (Добавил и добавление в заказы произошло!!! УРА!!!)
        }


        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Orders()
        {
            var orders = orderStorage.GetAllOrders();
            return View(orders);
        }

        public IActionResult OrderInDetail(Guid id)
        {
            var order = orderStorage.GetOrder(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult EditStatus(Guid id, OrderStatuses status)
        {
            var order = orderStorage.GetOrder(id);
            order.OrderStatus = status;
            return RedirectToAction("Orders");
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
