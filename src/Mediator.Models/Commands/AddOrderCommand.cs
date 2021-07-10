using MediatR;
using System;
using System.Collections.Generic;

namespace Mediator.Models
{
    public class AddOrderCommand: IRequest
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal Tax { get; set; }
    }
}
