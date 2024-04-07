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
        public List<Basket> orders = new List<Basket>();

        public void Add(Basket basket)
        {
            orders.Add(basket);
        }
    }
}
