using Mediator.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator.Logic.Handlers
{
    public class GetOrdersByIdHandler : IRequestHandler<GetOrdersByIdQuery, Order>
    {
        public async Task<Order> Handle(GetOrdersByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return OrderProvider.Orders
                    .FirstOrDefault(x => x.OrderId.Equals(request.OrderId));
            });
        }
    }
}
