using ASP_Homework_Product.Models;
using System.Collections.Generic;

namespace ASP_Homework_Product
{
	public interface IRolesStorage
	{
		void Add(Roles role);
		void Remove(Roles role);
		List<Roles> GetAllRoles();
	}
}
