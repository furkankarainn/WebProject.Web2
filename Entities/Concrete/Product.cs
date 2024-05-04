using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:BaseEntity,IEntity
    {
        public Product()
        {
            ProductPieces = new HashSet<ProductPiece>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? Code { get; set; }

        public ICollection<ProductPiece> ProductPieces { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
