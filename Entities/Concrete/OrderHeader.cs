using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderHeader:BaseEntity,IEntity
    {
        public OrderHeader()
        {
            OrderDetails=new HashSet<OrderDetail>();
        }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
