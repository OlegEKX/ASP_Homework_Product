using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ASP_Homework_Product.Models;

namespace ASP_Homework_Product
{
    // убрал static у класса
    public class InMemoryBasketStorage : IBasketStorage
	{
		
		private List<Basket> firstCarts = new List<Basket>();

        public List<Basket> carts
        {
            get { return firstCarts; }
        }

        public Basket TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingBasket = TryGetByUserId(userId);
            if (existingBasket == null)
            {
                var newBasket = new Basket()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<BasketItem>
                    {
                        new BasketItem()
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };

                carts.Add(newBasket);
            }
            else
            {
                var existingBasketItem = existingBasket.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingBasketItem != null)
                {
                    existingBasketItem.Amount += 1;
                }
                else
                {
                    existingBasket.Items.Add(new BasketItem()
                    {
						Id = Guid.NewGuid(),
						Product = product,
						Amount = 1
					});
                    
                }
            }

           

        }


		// для прибавки и удаления товара, который уже был добавлен в корзину
		public void Remove(Product product, string userid)
		{
            var existingBasket = TryGetByUserId(userid);
            var existingBasketItem = existingBasket.Items.FirstOrDefault(item => item.Product.Id == product.Id);

            existingBasketItem.Amount--;

			if (existingBasketItem.Amount == 0)
            {
                existingBasket.Items.Remove(existingBasketItem);
            }
            if (existingBasket.Items.Count == 0)
            {
                carts.Remove(existingBasket);
            }
		}

        public void Clear(string userId)
        {
            var existingBasket = TryGetByUserId(userId);
            carts.Remove(existingBasket);
		}
    }
}
