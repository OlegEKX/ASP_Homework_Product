using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ASP_Homework_Product.Models;

namespace ASP_Homework_Product.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public decimal Amount
        {
            get
            {
                return Items?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
