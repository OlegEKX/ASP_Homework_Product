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
	public class OrderController : Controller
	{

		private readonly IBasketStorage basketStorage;
		private readonly IConstants constants;
		private readonly IOrderStorage orderStorage;

		public OrderController(IBasketStorage basketStorage, IConstants constants, IOrderStorage orderStorage)
		{
			this.basketStorage = basketStorage;
			this.constants = constants;
			this.orderStorage = orderStorage;
		}

		public IActionResult Index()
		{
			Order userData = new Order();
			userData.Basket = basketStorage.TryGetByUserId(constants.UserId);
            //var basket = basketStorage.TryGetByUserId(constants.UserId);
			return View(userData);
		}

		[HttpPost]
		public IActionResult MakeOrder(Order userDataAndOrder)
		{
			if (ModelState.IsValid)
			{
                userDataAndOrder.Basket = basketStorage.TryGetByUserId(constants.UserId);
                orderStorage.Add(userDataAndOrder);

                basketStorage.Clear(constants.UserId);
                return View(userDataAndOrder);
            }
			return RedirectToAction("Index");
            /*var basket*/
            

			//return View("~/Views/Order/Success.cshtml");
		}
	}
}
