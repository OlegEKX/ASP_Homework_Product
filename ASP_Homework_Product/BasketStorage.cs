using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ASP_Homework_Product.Models;

namespace ASP_Homework_Product
{
    // убрал static у класса
    public class BasketStorage
    {
		
		private List<Basket> carts = new List<Basket>();

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
    }
}
