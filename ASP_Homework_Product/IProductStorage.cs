using ASP_Homework_Product.Models;
using System.Collections.Generic;

namespace ASP_Homework_Product
{
	public interface IProductStorage
	{
		List<Product> firstProducts { get;  }
		List<Product> GetProducts();

		Product TryGetById(int id);
	}
}
