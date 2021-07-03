using MediatR;
using System;
using System.Collections.Generic;

namespace Mediator.Models
{
    public class GetOrdersQuery: IRequest<List<Order>>
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
