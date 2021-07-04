using MediatR;
using System;
using System.Collections.Generic;

namespace Mediator.Models
{
    public class GetOrdersQuery: IRequest<List<Order>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> OrderStatuses { get; set; }
    }
}
