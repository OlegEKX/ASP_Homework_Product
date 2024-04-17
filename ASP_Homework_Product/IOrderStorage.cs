using ASP_Homework_Product.Models;

namespace ASP_Homework_Product
{
    public interface IOrderStorage
    {
        void Add(Basket basket);
    }
}
