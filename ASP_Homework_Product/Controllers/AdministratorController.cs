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
        private readonly IRolesStorage rolesStorage;

        public AdministratorController(IProductStorage productStorage, IOrderStorage orderStorage, IRolesStorage rolesStorage)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            // забыл добавить зависимость для IOrderStorage (Добавил и добавление в заказы произошло!!! УРА!!!)
            this.rolesStorage = rolesStorage;
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
            var roles = rolesStorage.GetAllRoles();
            return View(roles);
        }
        public IActionResult DeleteRole(int index)
        {
            var roles = rolesStorage.GetAllRoles();
            roles.RemoveAt(index);
            return RedirectToAction("Roles");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Roles role)
        {
            var roles = rolesStorage.GetAllRoles();

            if (roles.FirstOrDefault(x => x.Name == role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            rolesStorage.Add(role);
            return RedirectToAction("Roles");
        }

        public IActionResult Products()
        {
            var products = productStorage.GetProducts();
            return View(products);
        }
    }
}
