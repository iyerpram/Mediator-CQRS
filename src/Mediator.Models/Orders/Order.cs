using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int Tax { get; set; }
        public int Total
        {
            get
            {
                return (Products?.Sum(x => x.Price) ?? 0) + Tax;
            }
        }
    }
}
