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

		public OrderController(IBasketStorage basketStorage, IConstants constants)
		{
			this.basketStorage = basketStorage;
			this.constants = constants;
		}

		public IActionResult Index()
		{
			var basket = basketStorage.TryGetByUserId(constants.UserId);
			return View(basket);
		}

		[HttpPost]
		public IActionResult MakeOrder(Order userOrder)
		{
			basketStorage.Clear(constants.UserId);
			return View("~/Views/Order/Success.cshtml");
		}
	}
}
