using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Piece : BaseEntity,IEntity
    {
        public Piece()
        {
            ProductPieces = new HashSet<ProductPiece>();
        }
        public string Name { get; set; }
        public string? Type { get; set; }
        public int? Code { get; set; }

        public ICollection<ProductPiece> ProductPieces { get; set; }
    }
}
