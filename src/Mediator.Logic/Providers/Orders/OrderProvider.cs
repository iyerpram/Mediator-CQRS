using Mediator.Models;
using System;
using System.Collections.Generic;

namespace Mediator.Logic
{
    public class OrderProvider
    {
        private static List<Order> _orders = new List<Order> {
                new Order {
                    OrderId = 1,
                    OrderDate = DateTime.Parse("01/01/2021"),
                    OrderStatus = "Shipped",
                    Products = new List<Product> { 
                        new Product { 
                            Id = 1,
                            ProductName = "Samsung Mobile",
                            Price = 350
                        }
                    }
                },
                 new Order {
                    OrderId = 2,
                    OrderDate = DateTime.Parse("02/01/2021"),
                    OrderStatus = "Out for delivery",
                    Products = new List<Product> {
                        new Product {
                            Id = 1,
                            ProductName = "LG Refrigerator",
                            Price = 450
                        }
                    }
                },
                 new Order {
                    OrderId = 3,
                    OrderDate = DateTime.Parse("03/01/2021"),
                    OrderStatus = "Delivered",
                    Products = new List<Product> {
                        new Product {
                            Id = 1,
                            ProductName = "Samsung Tv",
                            Price = 550
                        }
                    }
                }
        };

        public static List<Order> Orders => _orders;
    }
}
