using Mediator.Models;
using MediatR;
using System.Linq;

namespace Mediator.Logic
{
    public class UpdateOrderHandler : RequestHandler<UpdateOrderCommand>
    {
        protected override void Handle(UpdateOrderCommand request)
        {
            var order = OrderProvider.Orders.FirstOrDefault(x => x.OrderId.Equals(request.OrderId));
            order.OrderStatus = request.OrderStatus;
        }
    }
}
