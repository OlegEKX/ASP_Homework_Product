using ASP_Homework_Product.Models;
using System;
using System.Collections.Generic;

namespace ASP_Homework_Product
{
    public interface IOrderStorage
    {
        void Add(Order userOrder);
        List<Order> GetAllOrders();
        Order GetOrder(Guid id);
    }
}
