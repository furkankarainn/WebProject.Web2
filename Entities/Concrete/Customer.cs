using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:BaseEntity,IEntity
    {
        public Customer()
        {
            OrderHeaders = new HashSet<OrderHeader>();
        }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? Company { get; set; }

        public ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
