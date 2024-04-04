using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ASP_Homework_Product.Models;

namespace ASP_Homework_Product
{
	public interface IBasketStorage
	{
		List<Basket> carts { get; }
		Basket TryGetByUserId(string userId);
		void Add(Product product, string userId);
		void Remove(Product product, string userid);
		void Clear(string userId);
	}
}
