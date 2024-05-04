using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderDetail:BaseEntity,IEntity
    {
        public Guid OrderHeaderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Amount { get; set; }

        public OrderHeader OrderHeader { get; set; }
        public Product Product { get; set; }
    }
}
