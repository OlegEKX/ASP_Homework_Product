using ASP_Homework_Product.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product
{
	public class InMemoryRolesStorage : IRolesStorage
	{
		List<Roles> roles = new List<Roles>()/* { new Roles("Admin")}*/;

		public void Add(Roles role)
		{
			roles.Add(role);
		}

		public void Remove(Roles role)
		{
			roles.Remove(role);
			/*foreach (var item in roles)
			{
				if (item.Name == role.Name)
				{
					roles.Remove(item);
				}
			}*/
		}

		public List<Roles> GetAllRoles()
		{
			return roles;
		}
	}
}
