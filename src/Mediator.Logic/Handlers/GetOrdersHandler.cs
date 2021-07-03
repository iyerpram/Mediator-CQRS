using Mediator.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator.Logic
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<Order>>
    {
        public async Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run<List<Order>>(() => new List<Order> {
                new Order {
                    OrderId = Guid.NewGuid(),
                    OrderDate = DateTime.Now.AddDays(-5),
                    OrderStatus = "Shipped",
                    Total = 1000.0M
                },
                 new Order {
                    OrderId = Guid.NewGuid(),
                    OrderDate = DateTime.Now.AddDays(-10),
                    OrderStatus = "Out for delivery",
                    Total = 1050.0M
                },
                 new Order {
                    OrderId = Guid.NewGuid(),
                    OrderDate = DateTime.Now.AddDays(-20),
                    OrderStatus = "Delivered",
                    Total = 2550.0M
                }
            });
        }
    }
}
