using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ASP_Homework_Product.Models;

namespace ASP_Homework_Product
{
    public class InMemoryOrderStorage : IOrderStorage
    {
        public List<Order> orders = new List<Order>();

        //DateTime date1 = DateTime.Now; //new DateTime(2015, 7, 20, 18, 30, 25);
		//DateTime.Now
		//Console.WriteLine(date1.ToShortDateString()); // 20.07.2015
		//Console.WriteLine(date1.ToShortTimeString()); // 18:30
		public void Add(Order userOrder)
        {
			//DateTime dateOfOrder = DateTime.Now;
            userOrder.DateTime = DateTime.Now;
            orders.Add(userOrder);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public Order GetOrder(Guid id)
        {
            foreach (var item in orders)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
            //var order = orders.FirstOrDefault(x => x.Id == id);
            //return order;

		}
    }
}
