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
                    Total = 1000.0M
                },
                 new Order {
                    OrderId = 2,
                    OrderDate = DateTime.Parse("02/01/2021"),
                    OrderStatus = "Out for delivery",
                    Total = 1050.0M
                },
                 new Order {
                    OrderId = 3,
                    OrderDate = DateTime.Parse("03/01/2021"),
                    OrderStatus = "Delivered",
                    Total = 2550.0M
                }
        };

        public static List<Order> Orders => _orders;
    }
}
