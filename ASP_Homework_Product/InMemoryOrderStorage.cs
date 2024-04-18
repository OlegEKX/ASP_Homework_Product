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

        public void Add(Order userOrder)
        {
            orders.Add(userOrder);
        }
    }
}
