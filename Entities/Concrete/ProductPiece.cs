using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductPiece : BaseEntity, IEntity
    {
        public Guid PieceId { get; set; }
        public Guid ProductId { get; set; }
        public string? Description { get; set; }

        public Piece Piece { get; set; }
        public Product Product { get; set; }
    }
}
