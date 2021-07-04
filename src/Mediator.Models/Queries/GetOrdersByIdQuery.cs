using MediatR;

namespace Mediator.Models
{
    public class GetOrdersByIdQuery: IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}
