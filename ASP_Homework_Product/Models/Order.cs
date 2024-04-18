using System;

namespace ASP_Homework_Product.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Basket Basket { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
    }
}
