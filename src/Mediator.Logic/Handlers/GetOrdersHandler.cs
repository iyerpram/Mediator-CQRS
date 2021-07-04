using Mediator.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator.Logic
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<Order>>
    {
        public async Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return OrderProvider.Orders
                    .Where(x => x.OrderDate >= request.StartDate && x.OrderDate <= request.EndDate 
                                && request.OrderStatuses.Any(status => x.OrderStatus.Equals(status, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            });
        }
    }
}
