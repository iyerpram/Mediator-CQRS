using MediatR;
using System.Collections.Generic;

namespace Mediator.Models
{
    public class UpdateOrderCommand: IRequest
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}
