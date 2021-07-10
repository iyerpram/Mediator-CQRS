using Mapster;
using Mediator.Models;
using MediatR;

namespace Mediator.Logic
{
    public class AddOrderHandler : RequestHandler<AddOrderCommand>
    {
        protected override void Handle(AddOrderCommand request)
        {
            var order = request.Adapt<Order>();
            OrderProvider.Orders.Add(order);
        }
    }
}
